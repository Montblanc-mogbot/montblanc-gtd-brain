"""tbh_single_table_exporter.py

Single-table exporter (one export per run), driven by an already-exported TICK.csv.

Primary mode (recommended for remaining ticket-related tables):
- Read a tkt_code set from an existing TICK CSV you already exported.
- Export one target table using:
    WHERE LTRIM(RTRIM(<target_tkt_code_col>)) IN (...)

Optional:
- Add a date filter IF the target table has a date column you want to restrict on.

This is intentionally minimal (meant for a small number of ad-hoc runs).
"""

from __future__ import annotations

import csv
import pathlib
from datetime import date
from typing import Any, Dict, Iterable, List, Optional, Tuple

from sqlalchemy import create_engine, text
from sqlalchemy.engine import Connection

# =====================
# CONFIG
# =====================

ENGINE_URL = "my engine url here"

# Where to write the output CSV
OUT_DIR = pathlib.Path("export_out_single")

# The table you want to export (one at a time)
TABLE = "TLAP"  # e.g. "TLAP", "TLAC", "TKTX", "TKTC", etc.

# How we will filter
MODE = "by_tick_codes"  # "by_tick_codes" or "by_date"

# ---- MODE = "by_tick_codes" ----
# Path to the *already-exported* TICK CSV that contains the ticket codes you want
TICK_CSV_PATH = pathlib.Path("export_out/202501/202501_TICK.csv")
TICK_CODE_COL = "tkt_code"  # column name in the TICK csv
TARGET_TKT_CODE_COL = "tkt_code"  # column name in the target table

# Optional: further restrict export by a date column in the *target table*.
# Set TARGET_DATE_COL=None to disable.
TARGET_DATE_COL: Optional[str] = None  # e.g. "order_date"
START_DATE: Optional[date] = None  # e.g. date(2025, 1, 1)
END_DATE: Optional[date] = None  # e.g. date(2025, 2, 1)

# Chunk size for IN (...) lists.
CHUNK_SIZE = 200


# =====================
# HELPERS
# =====================

def _chunks(xs: List[str], size: int) -> Iterable[List[str]]:
    for i in range(0, len(xs), size):
        yield xs[i : i + size]


def trim(v: Any) -> Any:
    return v.strip() if isinstance(v, str) else v


def write_csv(path: pathlib.Path, cols: List[str], rows: List[Tuple[Any, ...]]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("w", newline="", encoding="utf-8") as f:
        w = csv.writer(f)
        w.writerow(cols)
        for r in rows:
            w.writerow(list(r))


def select_all(
    conn: Connection,
    sql: str,
    params: Optional[Dict[str, Any]] = None,
) -> Tuple[List[str], List[Tuple[Any, ...]]]:
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
    params: Optional[Dict[str, Any]] = None,
) -> Tuple[List[str], List[Tuple[Any, ...]]]:
    """Run a SELECT with an IN clause in chunks.

    base_sql_with_in must contain a '{in_clause}' placeholder.

    Example:
        "SELECT * FROM ITRN WHERE LTRIM(RTRIM(invc_code)) IN ({in_clause})"
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


def read_codes_from_csv(path: pathlib.Path, col_name: str) -> List[str]:
    if not path.exists():
        raise FileNotFoundError(f"TICK_CSV_PATH not found: {path}")

    with path.open("r", newline="", encoding="utf-8") as f:
        r = csv.DictReader(f)
        if not r.fieldnames or col_name not in r.fieldnames:
            raise ValueError(
                f"CSV missing expected column '{col_name}'. Found columns: {r.fieldnames}"
            )

        out: List[str] = []
        for row in r:
            v = trim(row.get(col_name))
            if v:
                out.append(v)

    # unique + stable order
    return sorted(set(out))


def _validate_date_filter() -> None:
    if TARGET_DATE_COL is None:
        return
    if START_DATE is None or END_DATE is None:
        raise ValueError(
            "If TARGET_DATE_COL is set, you must set START_DATE and END_DATE."
        )


def _output_path() -> pathlib.Path:
    # Simple filename to make ad-hoc runs easy to recognize
    suffix = ""
    if MODE == "by_date":
        if START_DATE is None or END_DATE is None:
            suffix = "_UNKNOWN_RANGE"
        else:
            suffix = f"_{START_DATE.isoformat()}_{END_DATE.isoformat()}"
    elif MODE == "by_tick_codes":
        suffix = "_byTickCodes"
        if TARGET_DATE_COL and START_DATE and END_DATE:
            suffix += f"_{START_DATE.isoformat()}_{END_DATE.isoformat()}"

    return OUT_DIR / f"{TABLE}{suffix}.csv"


# =====================
# EXPORT
# =====================

def export_single_table(conn: Connection) -> None:
    out_path = _output_path()
    print(f"== Exporting TABLE={TABLE} MODE={MODE}")
    print(f"== Output: {out_path}")

    if MODE == "by_tick_codes":
        _validate_date_filter()

        tkt_codes = read_codes_from_csv(TICK_CSV_PATH, TICK_CODE_COL)
        print(f"== Loaded {len(tkt_codes):,} unique ticket codes from: {TICK_CSV_PATH}")

        where_parts = [f"LTRIM(RTRIM({TARGET_TKT_CODE_COL})) IN ({{in_clause}})"]
        params: Dict[str, Any] = {}

        if TARGET_DATE_COL is not None:
            where_parts.append(
                f"{TARGET_DATE_COL} >= :start AND {TARGET_DATE_COL} < :end"
            )
            params["start"] = START_DATE
            params["end"] = END_DATE

        sql = f"SELECT * FROM {TABLE} WHERE " + " AND ".join(where_parts)

        cols, rows = select_in_chunks(conn, sql, tkt_codes, CHUNK_SIZE, params)
        print(f"== Exported {len(rows):,} rows from {TABLE}")
        write_csv(out_path, cols, rows)

    elif MODE == "by_date":
        if START_DATE is None or END_DATE is None:
            raise ValueError("MODE='by_date' requires START_DATE and END_DATE.")
        if TARGET_DATE_COL is None:
            raise ValueError(
                "MODE='by_date' requires TARGET_DATE_COL (date column name)."
            )

        sql = (
            f"SELECT * FROM {TABLE} "
            f"WHERE {TARGET_DATE_COL} >= :start AND {TARGET_DATE_COL} < :end"
        )
        cols, rows = select_all(conn, sql, {"start": START_DATE, "end": END_DATE})
        print(f"== Exported {len(rows):,} rows from {TABLE}")
        write_csv(out_path, cols, rows)

    else:
        raise ValueError(f"Unknown MODE: {MODE}")

    print("Done.")


def main() -> None:
    engine = create_engine(ENGINE_URL)
    with engine.connect() as conn:
        export_single_table(conn)


if __name__ == "__main__":
    main()
