#!/usr/bin/env python3
"""Import a Command Alkon ITRN CSV export into a local SQLite "dummy" database.

Design goals:
- Zero external deps (stdlib only)
- Keep schema flexible: create a raw table with TEXT columns matching CSV header
- Convert the literal string "(null)" to SQL NULL

Usage:
  python tools/import_itrn_csv_to_sqlite.py \
    --csv data/itrn_sample.csv \
    --db  data/tbh_dummy.sqlite \
    --table itrn_raw \
    --drop
"""

from __future__ import annotations

import argparse
import csv
import os
import sqlite3
from typing import Iterable


def qident(name: str) -> str:
    # Quote identifiers safely for SQLite
    return '"' + name.replace('"', '""') + '"'


def normalize_cell(value: str | None) -> str | None:
    if value is None:
        return None
    v = value
    # common exports pad fixed-width fields
    v = v.strip()
    if v == "(null)" or v == "":
        return None
    return v


def chunks(it: Iterable[list], size: int):
    buf = []
    for x in it:
        buf.append(x)
        if len(buf) >= size:
            yield buf
            buf = []
    if buf:
        yield buf


def main() -> int:
    ap = argparse.ArgumentParser()
    ap.add_argument("--csv", required=True)
    ap.add_argument("--db", required=True)
    ap.add_argument("--table", default="itrn_raw")
    ap.add_argument("--drop", action="store_true")
    ap.add_argument("--batch", type=int, default=500)
    args = ap.parse_args()

    csv_path = args.csv
    db_path = args.db
    table = args.table

    os.makedirs(os.path.dirname(db_path), exist_ok=True)

    with open(csv_path, newline="", encoding="utf-8") as f:
        reader = csv.reader(f)
        header = next(reader)

        cols = [h.strip() for h in header]
        col_defs = ", ".join(f"{qident(c)} TEXT" for c in cols)

        conn = sqlite3.connect(db_path)
        try:
            conn.execute("PRAGMA journal_mode=WAL;")
            conn.execute("PRAGMA synchronous=NORMAL;")

            if args.drop:
                conn.execute(f"DROP TABLE IF EXISTS {qident(table)}")

            conn.execute(
                f"CREATE TABLE IF NOT EXISTS {qident(table)} (\n  {col_defs}\n)")

            placeholders = ", ".join(["?"] * len(cols))
            insert_sql = f"INSERT INTO {qident(table)} ({', '.join(map(qident, cols))}) VALUES ({placeholders})"

            def row_iter():
                for row in reader:
                    # Pad short rows defensively
                    if len(row) < len(cols):
                        row = row + [None] * (len(cols) - len(row))
                    elif len(row) > len(cols):
                        row = row[: len(cols)]
                    yield [normalize_cell(v) for v in row]

            total = 0
            for batch in chunks(row_iter(), args.batch):
                conn.executemany(insert_sql, batch)
                total += len(batch)
                conn.commit()

            print(f"Imported {total} rows into {db_path} table {table}")
        finally:
            conn.close()

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
