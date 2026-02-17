#!/usr/bin/env python3
"""Montblanc export (SQLAlchemy + pymssql, SELECT-only).

Purpose:
- Export 2 months of 2025 data for reconciliation without ODBC drivers and without temp tables.
- Uses ONLY SELECT statements.

Requirements:
  pip install sqlalchemy pymssql

Connection:
  Set ENGINE_URL below to your SQLAlchemy URL, e.g.
    ENGINE_URL = "mssql+pymssql://USER:PASSWORD@HOST:1433/DBNAME"

Outputs:
  export_out/reference/<TABLE>.csv
  export_out/YYYYMM/YYYYMM_<TABLE>.csv

Notes on performance/safety:
- Uses chunked IN-lists (default 500) to avoid huge parameter lists.
- Still SELECT-only; should not modify any data.
"""

from __future__ import annotations

import csv
import pathlib
from datetime import date
from typing import Iterable, List, Tuple, Set, Dict, Any

from sqlalchemy import create_engine, text
from sqlalchemy.engine import Connection


# =====================
# CONFIG
# =====================

ENGINE_URL = "mssql+pymssql://USER:PASSWORD@HOST:1433/DBNAME"  # <-- EDIT ME

OUT_DIR = pathlib.Path("export_out")
YEAR = 2025
START_MONTH = 1
MONTHS = 2

REF_TABLES = ["PLNT", "CUST", "IMST", "UOMS"]

# Chunk size for IN (...) lists.
CHUNK_SIZE = 500


# =====================
# HELPERS
# =====================

def month_range(year: int, start_month: int, months: int) -> List[Tuple[date, date, str]]:
    ranges = []
    y, m = year, start_month
    for _ in range(months):
        start = date(y, m, 1)
        end = date(y + 1, 1, 1) if m == 12 else date(y, m + 1, 1)
        ranges.append((start, end, f"{y:04d}{m:02d}"))
        m += 1
        if m == 13:
            m = 1
            y += 1
    return ranges


def _chunks(xs: List[str], size: int) -> Iterable[List[str]]:
    for i in range(0, len(xs), size):
        yield xs[i : i + size]


def write_csv(path: pathlib.Path, cols: List[str], rows: List[Tuple[Any, ...]]):
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("w", newline="", encoding="utf-8") as f:
        w = csv.writer(f)
        w.writerow(cols)
        for r in rows:
            w.writerow(list(r))


def trim(v: Any) -> Any:
    return v.strip() if isinstance(v, str) else v


def select_all(conn: Connection, sql: str, params: Dict[str, Any] | None = None) -> Tuple[List[str], List[Tuple[Any, ...]]]:
    """Run a SELECT and return (columns, rows)."""
    params = params or {}
    result = conn.execute(text(sql), params)
    cols = list(result.keys())
    rows = [tuple(r) for r in result.fetchall()]
    return cols, rows


def select_in_chunks(
    conn: Connection,
    base_sql_with_in: str,
    values: List[str],
    chunk_size: int,
    params: Dict[str, Any] | None = None,
) -> Tuple[List[str], List[Tuple[Any, ...]]]:
    """Run a SELECT with an IN clause in chunks.

    base_sql_with_in must contain a '{in_clause}' placeholder.
    Example:
      "SELECT * FROM ITRN WHERE LTRIM(RTRIM(invc_code)) IN ({in_clause})"

    params: dict of named params used elsewhere in the SQL.
    """
    params = params or {}
    all_rows: List[Tuple[Any, ...]] = []
    cols_out: List[str] = []

    if not values:
        return cols_out, all_rows

    for chunk in _chunks(values, chunk_size):
        chunk_params = dict(params)
        placeholders: List[str] = []
        for j, v in enumerate(chunk):
            k = f"v{j}"
            placeholders.append(f":{k}")
            chunk_params[k] = v

        sql = base_sql_with_in.format(in_clause=",".join(placeholders))
        cols, rows = select_all(conn, sql, chunk_params)
        if not cols_out:
            cols_out = cols
        all_rows.extend(rows)

    return cols_out, all_rows


# =====================
# EXPORTS
# =====================

def run_exports(conn: Connection):
    # 0) Reference tables (once)
    ref_dir = OUT_DIR / "reference"
    for t in REF_TABLES:
        cols, rows = select_all(conn, f"SELECT * FROM {t}")
        write_csv(ref_dir / f"{t}.csv", cols, rows)

    for start, end, yyyymm in month_range(YEAR, START_MONTH, MONTHS):
        month_dir = OUT_DIR / yyyymm
        print(f"== Exporting {yyyymm}: {start} -> {end}")

        # 1) TICK (driver) by order_date window
        tick_cols, tick_rows = select_all(
            conn,
            "SELECT * FROM TICK WHERE order_date >= :start AND order_date < :end",
            {"start": start, "end": end},
        )
        write_csv(month_dir / f"{yyyymm}_TICK.csv", tick_cols, tick_rows)

        # 2) Build ticket code + invoice sets from TICK
        tkt_idx = tick_cols.index("tkt_code")
        invc_idx = tick_cols.index("invc_code")

        tkt_codes = sorted({trim(r[tkt_idx]) for r in tick_rows if trim(r[tkt_idx])})
        invc_codes = sorted({trim(r[invc_idx]) for r in tick_rows if trim(r[invc_idx])})

        # 3) TKTL by order_date window + tkt_code IN (...)
        tktl_sql = (
            "SELECT * FROM TKTL "
            "WHERE order_date >= :start AND order_date < :end "
            "AND LTRIM(RTRIM(tkt_code)) IN ({in_clause})"
        )
        tktl_cols, tktl_rows = select_in_chunks(
            conn,
            tktl_sql,
            tkt_codes,
            CHUNK_SIZE,
            {"start": start, "end": end},
        )
        write_csv(month_dir / f"{yyyymm}_TKTL.csv", tktl_cols, tktl_rows)

        # 4) TKTC by order_date window + tkt_code IN (...)
        tktc_sql = (
            "SELECT * FROM TKTC "
            "WHERE order_date >= :start AND order_date < :end "
            "AND LTRIM(RTRIM(tkt_code)) IN ({in_clause})"
        )
        tktc_cols, tktc_rows = select_in_chunks(
            conn,
            tktc_sql,
            tkt_codes,
            CHUNK_SIZE,
            {"start": start, "end": end},
        )
        write_csv(month_dir / f"{yyyymm}_TKTC.csv", tktc_cols, tktc_rows)

        # 5) ORDR/ORDL by order_date window
        ordr_cols, ordr_rows = select_all(
            conn,
            "SELECT * FROM ORDR WHERE order_date >= :start AND order_date < :end",
            {"start": start, "end": end},
        )
        write_csv(month_dir / f"{yyyymm}_ORDR.csv", ordr_cols, ordr_rows)

        ordl_cols, ordl_rows = select_all(
            conn,
            "SELECT * FROM ORDL WHERE order_date >= :start AND order_date < :end",
            {"start": start, "end": end},
        )
        write_csv(month_dir / f"{yyyymm}_ORDL.csv", ordl_cols, ordl_rows)

        # 6) ITRN by invoice set AND by trans_date window
        itrn_by_invc_sql = "SELECT * FROM ITRN WHERE LTRIM(RTRIM(invc_code)) IN ({in_clause})"
        itrn_cols_a, itrn_rows_a = select_in_chunks(
            conn,
            itrn_by_invc_sql,
            invc_codes,
            CHUNK_SIZE,
            {},
        )

        itrn_cols_b, itrn_rows_b = select_all(
            conn,
            "SELECT * FROM ITRN WHERE trans_date IS NOT NULL AND trans_date >= :start AND trans_date < :end",
            {"start": start, "end": end},
        )

        write_csv(month_dir / f"{yyyymm}_ITRN_ByInvoice.csv", itrn_cols_a, itrn_rows_a)
        write_csv(month_dir / f"{yyyymm}_ITRN_ByTransDate.csv", itrn_cols_b, itrn_rows_b)

        # 7) ARTB by invoice set (item_ref_code)
        artb_sql = "SELECT * FROM ARTB WHERE LTRIM(RTRIM(item_ref_code)) IN ({in_clause})"
        artb_cols, artb_rows = select_in_chunks(
            conn,
            artb_sql,
            invc_codes,
            CHUNK_SIZE,
            {},
        )
        write_csv(month_dir / f"{yyyymm}_ARTB.csv", artb_cols, artb_rows)

        # 8) GLDT: pull by batch_date window, then filter locally to exact ITRN batch keys
        gldt_cols, gldt_rows = select_all(
            conn,
            "SELECT * FROM GLDT WHERE batch_date IS NOT NULL AND batch_date >= :start AND batch_date < :end",
            {"start": start, "end": end},
        )

        # batch key set from ITRN trans-date window
        bd_i = itrn_cols_b.index("batch_date")
        bn_i = itrn_cols_b.index("batch_num")
        bs_i = itrn_cols_b.index("batch_seq")

        batch_keys: Set[Tuple[str, str, str]] = set()
        for r in itrn_rows_b:
            bd = r[bd_i]
            bn = trim(r[bn_i])
            bs = trim(r[bs_i])
            if bd and bn and bs:
                bd_txt = bd.strftime("%Y-%m-%d %H:%M:%S") if hasattr(bd, "strftime") else str(bd)
                batch_keys.add((bd_txt, bn, bs))

        g_bd_i = gldt_cols.index("batch_date")
        g_bn_i = gldt_cols.index("batch_num")
        g_bs_i = gldt_cols.index("batch_seq")

        filtered_gldt: List[Tuple[Any, ...]] = []
        for r in gldt_rows:
            bd = r[g_bd_i]
            bn = trim(r[g_bn_i])
            bs = trim(r[g_bs_i])
            if not (bd and bn and bs):
                continue
            bd_txt = bd.strftime("%Y-%m-%d %H:%M:%S") if hasattr(bd, "strftime") else str(bd)
            if (bd_txt, bn, bs) in batch_keys:
                filtered_gldt.append(r)

        write_csv(month_dir / f"{yyyymm}_GLDT.csv", gldt_cols, filtered_gldt)

    print("Done.")


def main():
    engine = create_engine(ENGINE_URL)
    with engine.connect() as conn:
        run_exports(conn)


if __name__ == "__main__":
    main()
