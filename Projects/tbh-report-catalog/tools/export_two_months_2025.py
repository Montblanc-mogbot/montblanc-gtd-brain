#!/usr/bin/env python3
"""Export 2 months of 2025 Command Alkon data for reconciliation.

Design (recon-friendly):
- Prefer ORDER_DATE for dispatch tables.
- Export TICK for the window, then export TKTL/TKTC by the exact ticket keys
  (order_date, order_code, tkt_code) so we don’t miss surcharge/admixture lines.
- Export AR (ITRN, ARTB) by the invoice set present in TICK for the window.
- Export GLDT by ITRN batch keys (batch_date, batch_num, batch_seq) for the window.

Usage:
  pip install pyodbc
  export ODBC_CONN_STR="DRIVER={ODBC Driver 17 for SQL Server};SERVER=...;DATABASE=...;UID=...;PWD=..."
  export YEAR=2025
  export START_MONTH=1   # Jan
  export MONTHS=2        # Jan+Feb
  export OUT_DIR=export_out
  python export_two_months_2025.py

Outputs:
  OUT_DIR/reference/<TABLE>.csv
  OUT_DIR/YYYYMM/YYYYMM_<TABLE>.csv

Notes:
- This script is written for SQL Server syntax (temp tables #...).
- If your DB is not SQL Server, tell me and I’ll adapt the temp-table pieces.
"""

import os
import csv
import sys
import pathlib
from datetime import date
from typing import List, Tuple, Set

import pyodbc


def month_range(year: int, start_month: int, months: int) -> List[Tuple[date, date, str]]:
    ranges = []
    y, m = year, start_month
    for _ in range(months):
        start = date(y, m, 1)
        if m == 12:
            end = date(y + 1, 1, 1)
        else:
            end = date(y, m + 1, 1)
        ranges.append((start, end, f"{y:04d}{m:02d}"))
        m += 1
        if m == 13:
            m = 1
            y += 1
    return ranges


def connect() -> pyodbc.Connection:
    conn_str = os.environ.get("ODBC_CONN_STR")
    if not conn_str:
        print("Missing env var ODBC_CONN_STR", file=sys.stderr)
        sys.exit(2)
    return pyodbc.connect(conn_str)


def query_rows(conn: pyodbc.Connection, sql: str, params: Tuple = ()) -> Tuple[List[str], List[Tuple]]:
    cur = conn.cursor()
    cur.execute(sql, params)
    cols = [d[0] for d in cur.description]
    rows = cur.fetchall()
    return cols, [tuple(r) for r in rows]


def write_csv(path: pathlib.Path, cols: List[str], rows: List[Tuple]):
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("w", newline="", encoding="utf-8") as f:
        w = csv.writer(f)
        w.writerow(cols)
        for r in rows:
            w.writerow(list(r))


def _trim(v):
    return v.strip() if isinstance(v, str) else v


def export_by_date_window(conn, table: str, start: date, end: date, out_path: pathlib.Path, date_col: str):
    sql = f"SELECT * FROM {table} WHERE {date_col} >= ? AND {date_col} < ?"
    cols, rows = query_rows(conn, sql, (start, end))
    write_csv(out_path, cols, rows)


def fetch_tick_keys_and_invoices(conn, start: date, end: date) -> Tuple[List[Tuple], Set[str]]:
    """Return ticket keys (order_date, order_code, tkt_code) and invc_codes from TICK in the window."""
    sql = """
    SELECT order_date, order_code, tkt_code, invc_code
    FROM TICK
    WHERE order_date >= ? AND order_date < ?
    """
    cols, rows = query_rows(conn, sql, (start, end))
    od_i = cols.index("order_date")
    oc_i = cols.index("order_code")
    tk_i = cols.index("tkt_code")
    iv_i = cols.index("invc_code")

    keys: List[Tuple] = []
    invc: Set[str] = set()
    for r in rows:
        od = r[od_i]
        oc = _trim(r[oc_i])
        tk = _trim(r[tk_i])
        iv = _trim(r[iv_i])
        keys.append((od, oc, tk))
        if iv:
            invc.add(iv)
    return keys, invc


def export_by_ticket_keys(conn, table: str, keys: List[Tuple], out_path: pathlib.Path):
    """Export rows for TKTL/TKTC using exact (order_date, order_code, tkt_code) keys."""
    cur = conn.cursor()

    cur.execute("IF OBJECT_ID('tempdb..#ticket_keys') IS NOT NULL DROP TABLE #ticket_keys;")
    cur.execute(
        """
        CREATE TABLE #ticket_keys (
          order_date DATETIME,
          order_code VARCHAR(50),
          tkt_code   VARCHAR(50)
        );
        """
    )

    cur.fast_executemany = True
    cur.executemany(
        "INSERT INTO #ticket_keys(order_date, order_code, tkt_code) VALUES (?, ?, ?);",
        keys,
    )

    sql = f"""
      SELECT t.*
      FROM {table} t
      JOIN #ticket_keys k
        ON t.order_date = k.order_date
       AND LTRIM(RTRIM(t.order_code)) = LTRIM(RTRIM(k.order_code))
       AND LTRIM(RTRIM(t.tkt_code))   = LTRIM(RTRIM(k.tkt_code))
    """
    cols, rows = query_rows(conn, sql, ())
    write_csv(out_path, cols, rows)

    cur.execute("DROP TABLE #ticket_keys;")


def export_by_invoice_codes(conn, table: str, invc_codes: Set[str], out_path: pathlib.Path, invc_col: str):
    """Export AR rows for invoice set (Dispatch→AR recon)."""
    cur = conn.cursor()

    cur.execute("IF OBJECT_ID('tempdb..#invc_codes') IS NOT NULL DROP TABLE #invc_codes;")
    cur.execute("CREATE TABLE #invc_codes (invc_code VARCHAR(50));")

    cur.fast_executemany = True
    cur.executemany("INSERT INTO #invc_codes(invc_code) VALUES (?);", [(x,) for x in sorted(invc_codes)])

    sql = f"""
      SELECT a.*
      FROM {table} a
      JOIN #invc_codes i
        ON LTRIM(RTRIM(a.{invc_col})) = LTRIM(RTRIM(i.invc_code))
    """
    cols, rows = query_rows(conn, sql, ())
    write_csv(out_path, cols, rows)

    cur.execute("DROP TABLE #invc_codes;")


def fetch_itrn_batch_keys(conn, start: date, end: date) -> List[Tuple]:
    """Return distinct (batch_date, batch_num, batch_seq) for ITRN rows in the window (AR→GL recon)."""
    sql = """
    SELECT DISTINCT batch_date, batch_num, batch_seq
    FROM ITRN
    WHERE trans_date IS NOT NULL
      AND trans_date >= ? AND trans_date < ?
      AND batch_date IS NOT NULL
      AND batch_num IS NOT NULL
      AND batch_seq IS NOT NULL
    """
    _, rows = query_rows(conn, sql, (start, end))
    return rows


def export_gldt_by_batch_keys(conn, batch_keys: List[Tuple], out_path: pathlib.Path):
    """Export GLDT rows matching the ITRN batch keys."""
    cur = conn.cursor()

    cur.execute("IF OBJECT_ID('tempdb..#batch_keys') IS NOT NULL DROP TABLE #batch_keys;")
    cur.execute(
        """
        CREATE TABLE #batch_keys (
          batch_date DATETIME,
          batch_num  VARCHAR(50),
          batch_seq  VARCHAR(50)
        );
        """
    )

    cur.fast_executemany = True
    cur.executemany(
        "INSERT INTO #batch_keys(batch_date, batch_num, batch_seq) VALUES (?, ?, ?);",
        batch_keys,
    )

    sql = """
      SELECT g.*
      FROM GLDT g
      JOIN #batch_keys b
        ON g.batch_date = b.batch_date
       AND LTRIM(RTRIM(g.batch_num)) = LTRIM(RTRIM(b.batch_num))
       AND LTRIM(RTRIM(g.batch_seq)) = LTRIM(RTRIM(b.batch_seq))
    """
    cols, rows = query_rows(conn, sql, ())
    write_csv(out_path, cols, rows)

    cur.execute("DROP TABLE #batch_keys;")


def main():
    YEAR = int(os.environ.get("YEAR", "2025"))
    START_MONTH = int(os.environ.get("START_MONTH", "1"))
    MONTHS = int(os.environ.get("MONTHS", "2"))
    OUT_DIR = pathlib.Path(os.environ.get("OUT_DIR", "export_out"))

    # Reference tables (export once)
    REF_TABLES = ["PLNT", "CUST", "IMST", "UOMS"]

    conn = connect()

    ref_out = OUT_DIR / "reference"
    for t in REF_TABLES:
        cols, rows = query_rows(conn, f"SELECT * FROM {t}", ())
        write_csv(ref_out / f"{t}.csv", cols, rows)

    for start, end, yyyymm in month_range(YEAR, START_MONTH, MONTHS):
        month_dir = OUT_DIR / yyyymm
        print(f"== Exporting {yyyymm}: {start} -> {end}")

        # Dispatch/order driver set
        export_by_date_window(conn, "TICK", start, end, month_dir / f"{yyyymm}_TICK.csv", date_col="order_date")

        # Extract keys + invoice set from TICK
        ticket_keys, invc_codes = fetch_tick_keys_and_invoices(conn, start, end)

        # Ticket detail (must be key-driven)
        export_by_ticket_keys(conn, "TKTL", ticket_keys, month_dir / f"{yyyymm}_TKTL.csv")
        export_by_ticket_keys(conn, "TKTC", ticket_keys, month_dir / f"{yyyymm}_TKTC.csv")

        # Orders (window by order_date)
        export_by_date_window(conn, "ORDR", start, end, month_dir / f"{yyyymm}_ORDR.csv", date_col="order_date")
        export_by_date_window(conn, "ORDL", start, end, month_dir / f"{yyyymm}_ORDL.csv", date_col="order_date")

        # AR exports (invoice-driven from dispatch)
        export_by_invoice_codes(conn, "ITRN", invc_codes, month_dir / f"{yyyymm}_ITRN.csv", invc_col="invc_code")
        export_by_invoice_codes(conn, "ARTB", invc_codes, month_dir / f"{yyyymm}_ARTB.csv", invc_col="item_ref_code")

        # GLDT exports (batch-driven from ITRN)
        batch_keys = fetch_itrn_batch_keys(conn, start, end)
        export_gldt_by_batch_keys(conn, batch_keys, month_dir / f"{yyyymm}_GLDT.csv")

    conn.close()
    print("Done.")


if __name__ == "__main__":
    main()
