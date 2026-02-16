#!/usr/bin/env python3
"""
Build SQLite dummy database from sample CSV files.
Usage: python scripts/sqlite/build_dummy_db.py
"""
import sqlite3
import csv
import os
from pathlib import Path

DB_PATH = Path(__file__).parent.parent.parent / "data" / "command_alkon_dummy.db"
DATA_DIR = Path(__file__).parent.parent.parent / "data"

# Raw extract samples (copied into Projects/tbh-report-catalog/data/)
ITRN_CSV_PATH = DATA_DIR / "itrn_sample.csv"
TICK_CSV_PATH = DATA_DIR / "tick_sample.csv"
TKTL_CSV_PATH = DATA_DIR / "tktl_sample.csv"
ORDR_CSV_PATH = DATA_DIR / "ordr_sample.csv"


def _read_csv_header(path: Path):
    if not path.exists():
        return None
    with open(path, 'r', encoding='utf-8', newline='') as f:
        reader = csv.reader(f)
        return next(reader)


def _create_table_from_csv_header(cursor: sqlite3.Cursor, table_name: str, csv_path: Path, fallback_columns: list[str]):
    """Create a SQLite table with TEXT columns matching the CSV header.

    We intentionally use TEXT for raw extracts to avoid fighting type inference.
    Normalization/analytics layers can do typed parsing.
    """
    cols = _read_csv_header(csv_path)
    if cols is None:
        quoted_cols = [f'"{c}" TEXT' for c in fallback_columns]
    else:
        quoted_cols = [f'"{c}" TEXT' for c in cols]

    cursor.execute(f"CREATE TABLE {table_name} (\n        {',\n        '.join(quoted_cols)}\n    )")

def init_database():
    """Create fresh database with schema."""
    DB_PATH.parent.mkdir(exist_ok=True)

    if DB_PATH.exists():
        DB_PATH.unlink()
        print(f"Removed existing: {DB_PATH}")

    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()

    # ORDL table schema (Order Detail) - January 2025 sample
    cursor.execute('''
    CREATE TABLE ordl (
        order_date TEXT, order_code TEXT, order_intrnl_line_num INTEGER, sort_line_num INTEGER,
        prod_code TEXT, prod_descr TEXT, short_prod_descr TEXT, prod_cat TEXT,
        price REAL, cstmry_price REAL, metric_price REAL, price_uom TEXT, cstmry_price_uom TEXT, metric_price_uom TEXT,
        price_derived_from_code TEXT, price_ext_code TEXT, price_qty REAL, delv_price_flag TEXT,
        dflt_load_qty REAL, cstmry_dflt_load_qty REAL, metric_dflt_load_qty REAL, dflt_load_qty_uom TEXT,
        order_qty_ext_code TEXT, order_dosage_qty REAL, cstmry_order_dosage_qty REAL, metric_order_dosage_qty REAL,
        order_dosage_qty_uom TEXT, cstmry_order_dosage_qty_uom TEXT, metric_order_dosage_qty_uom TEXT,
        price_qty_ext_code TEXT, tkt_qty_ext_code TEXT, cred_price_adj_flag TEXT, cred_cost_adj_flag TEXT,
        order_qty REAL, cstmry_order_qty REAL, metric_order_qty REAL, order_qty_uom TEXT,
        cstmry_order_qty_uom TEXT, metric_order_qty_uom TEXT, orig_order_qty REAL, cstmry_orig_order_qty REAL,
        metric_orig_order_qty REAL, delv_qty REAL, cstmry_delv_qty REAL, metric_delv_qty REAL,
        delv_qty_uom TEXT, cstmry_delv_qty_uom TEXT, metric_delv_qty_uom TEXT, delv_to_date_qty REAL,
        cstmry_delv_to_date_qty REAL, metric_delv_to_date_qty REAL, rm_slump TEXT, rm_slump_uom TEXT,
        rm_mix_flag TEXT, comment_text TEXT, usage_code TEXT, taxble_code TEXT, non_tax_rsn_code TEXT,
        invc_flag TEXT, sep_invc_flag TEXT, remove_rsn_code TEXT, proj_line_num TEXT, cust_line_num TEXT,
        curr_load_num TEXT, quote_code TEXT, am_min_temp TEXT, moved_order_date TEXT, moved_to_order_code TEXT,
        moved_from_order_code TEXT, invy_adjust_code TEXT, sales_anl_adjust_code TEXT, mix_design_user_name TEXT,
        mix_design_update_date TEXT, qc_approvl_flag TEXT, qc_approvl_date TEXT, batch_code TEXT,
        chrg_cart_code TEXT, cart_rate_amt REAL, quote_rev_num TEXT, type_price TEXT, matl_price REAL,
        mix_sent_to_lab_status TEXT, lab_transfer_date TEXT, auth_user_name TEXT, linked_prod_seq_num TEXT,
        linked_prod_time_gap TEXT, cart_cat TEXT, additional_samples TEXT, apply_to_contract TEXT,
        contracted_samples TEXT, exclude_from_sample_sched_rpt TEXT, total_samples_to_take TEXT,
        pct_hydrate TEXT, pumped_indicator_code TEXT, writeoff_qty TEXT, writeoff_first_load_flag TEXT,
        record_origin_code TEXT, other_form_chng_code TEXT, update_date TEXT, u_version TEXT
    )
    ''')
    
    # TKTC table schema (Ticket Charges) - January 2021 sample
    cursor.execute('''
    CREATE TABLE tktc (
        order_date TEXT, order_code TEXT, tkt_code TEXT, tkt_chrg_intrnl_line_num INTEGER,
        tkt_chrg_code TEXT, sundry_chrg_table_id TEXT, unld_chrg_table_id TEXT,
        prod_code TEXT, prod_descr TEXT, short_prod_descr TEXT, prod_cat TEXT,
        price REAL, cstmry_price REAL, metric_price REAL, price_uom TEXT, cstmry_price_uom TEXT, metric_price_uom TEXT,
        price_derived_from_code TEXT, price_ext_code TEXT, taxble_code TEXT, non_tax_rsn_code TEXT,
        delv_qty REAL, cstmry_delv_qty REAL, metric_delv_qty REAL, delv_qty_uom TEXT,
        cstmry_delv_qty_uom TEXT, metric_delv_qty_uom TEXT, ext_price_amt REAL, price_qty REAL,
        cstmry_price_qty REAL, metric_price_qty REAL, cost REAL, cost_uom TEXT, cstmry_cost REAL,
        metric_cost REAL, cost_ext_code TEXT, ext_matl_cost_amt REAL, moved_order_date TEXT,
        moved_to_order_code TEXT, moved_from_order_code TEXT, delv_price_flag TEXT, comb_meth_code TEXT,
        usage_code TEXT, order_intrnl_line_num INTEGER, invc_round_diff_amt REAL, update_date TEXT, u_version TEXT
    )
    ''')

    # PLNT table schema (Plant Master)
    cursor.execute('''
    CREATE TABLE plnt (
        plant_code TEXT PRIMARY KEY, name TEXT, short_name TEXT, addr_line_1 TEXT,
        addr_city TEXT, addr_state TEXT, addr_postcd TEXT, comp_code TEXT, loc_code TEXT,
        phone_num TEXT, zone_code TEXT, tax_code TEXT, max_batch_size REAL, plant_load_time REAL,
        driv_lead_time REAL, plant_yard_time REAL, update_date TEXT
    )
    ''')

    # CUST table schema (Customer Master)
    cursor.execute('''
    CREATE TABLE cust (
        cust_code TEXT PRIMARY KEY, name TEXT, sort_name TEXT, addr_line_1 TEXT,
        addr_city TEXT, addr_state TEXT, addr_postcd TEXT, phone_num_1 TEXT,
        contct_name TEXT, setup_date TEXT, tax_code TEXT, inactive_code TEXT, update_date TEXT
    )
    ''')

    # IMST table schema (Item Master)
    cursor.execute('''
    CREATE TABLE imst (
        item_code TEXT PRIMARY KEY, descr TEXT, short_descr TEXT, item_cat TEXT,
        matl_type TEXT, order_uom TEXT, price_uom TEXT, taxble_code INTEGER,
        print_on_tkt_flag INTEGER, const_flag INTEGER, update_date TEXT
    )
    ''')

    # ITRN / TICK / TKTL / ORDR schemas
    # We generate schema directly from the CSV header to avoid hand-maintaining 100+ columns.
    _create_table_from_csv_header(cursor, "itrn", ITRN_CSV_PATH, fallback_columns=[
        "invc_code",
        "trans_type",
        "trans_date",
    ])

    # Primary dispatch tables
    _create_table_from_csv_header(cursor, "tick", TICK_CSV_PATH, fallback_columns=[
        "order_date",
        "order_code",
        "tkt_code",
        "tkt_date",
        "ship_plant_code",
    ])
    _create_table_from_csv_header(cursor, "tktl", TKTL_CSV_PATH, fallback_columns=[
        "order_date",
        "order_code",
        "tkt_code",
        "order_intrnl_line_num",
        "ext_price_amt",
        "ship_plant_code",
    ])

    # Order header (needed for authoritative order context)
    _create_table_from_csv_header(cursor, "ordr", ORDR_CSV_PATH, fallback_columns=[
        "order_date",
        "order_code",
        "cust_code",
        "cust_name",
    ])

    conn.commit()
    conn.close()
    print(f"Created: {DB_PATH}")

def load_ordl():
    """Load ORDL (Order Detail) sample data."""
    csv_path = DATA_DIR / "ordl_sample.csv"
    if not csv_path.exists():
        print(f"Warning: {csv_path} not found")
        return 0
    
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    
    cursor.execute("DELETE FROM ordl")
    
    with open(csv_path, 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f, delimiter=',')
        
        columns = reader.fieldnames
        placeholders = ','.join(['?' for _ in columns])
        
        insert_sql = f"INSERT INTO ordl ({','.join(columns)}) VALUES ({placeholders})"
        
        rows_inserted = 0
        for row in reader:
            values = [None if v == "(null)" else v for v in row.values()]
            cursor.execute(insert_sql, values)
            rows_inserted += 1
        
        conn.commit()
    
    conn.close()
    print(f"Loaded {rows_inserted} rows into ordl")
    return rows_inserted

def load_tktc():
    """Load TKTC (Ticket Charges) sample data."""
    csv_path = DATA_DIR / "tktc_sample.csv"
    if not csv_path.exists():
        print(f"Warning: {csv_path} not found")
        return 0
    
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    
    cursor.execute("DELETE FROM tktc")
    
    with open(csv_path, 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f, delimiter=',')
        
        columns = reader.fieldnames
        placeholders = ','.join(['?' for _ in columns])
        
        insert_sql = f"INSERT INTO tktc ({','.join(columns)}) VALUES ({placeholders})"
        
        rows_inserted = 0
        for row in reader:
            values = [None if v == "(null)" else v for v in row.values()]
            cursor.execute(insert_sql, values)
            rows_inserted += 1
        
        conn.commit()
    
    conn.close()
    print(f"Loaded {rows_inserted} rows into tktc")
    return rows_inserted

def load_plnt():
    """Load PLNT (Plant Master) sample data."""
    csv_path = DATA_DIR / "plnt_sample.csv"
    if not csv_path.exists():
        print(f"Warning: {csv_path} not found")
        return 0
    
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    
    cursor.execute("DELETE FROM plnt")
    
    with open(csv_path, 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f, delimiter=',')
        
        rows_inserted = 0
        for row in reader:
            # Only extract the columns we care about
            cursor.execute('''
                INSERT INTO plnt (plant_code, name, short_name, addr_line_1, addr_city, addr_state, 
                                  addr_postcd, comp_code, loc_code, phone_num, zone_code, tax_code,
                                  max_batch_size, plant_load_time, driv_lead_time, plant_yard_time, update_date)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            ''', [
                row.get('plant_code'),
                row.get('name'),
                row.get('short_name'),
                row.get('addr_line_1'),
                row.get('addr_city'),
                row.get('addr_state'),
                row.get('addr_postcd'),
                row.get('comp_code'),
                row.get('loc_code'),
                row.get('phone_num'),
                row.get('zone_code'),
                row.get('tax_code'),
                row.get('max_batch_size'),
                row.get('plant_load_time'),
                row.get('driv_lead_time'),
                row.get('plant_yard_time'),
                row.get('update_date')
            ])
            rows_inserted += 1
        
        conn.commit()
    
    conn.close()
    print(f"Loaded {rows_inserted} rows into plnt")
    return rows_inserted

def load_cust():
    """Load CUST (Customer Master) sample data."""
    csv_path = DATA_DIR / "cust_sample.csv"
    if not csv_path.exists():
        print(f"Warning: {csv_path} not found")
        return 0
    
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    
    cursor.execute("DELETE FROM cust")
    
    with open(csv_path, 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f, delimiter=',')
        
        rows_inserted = 0
        for row in reader:
            cursor.execute('''
                INSERT INTO cust (cust_code, name, sort_name, addr_line_1, addr_city, addr_state,
                                  addr_postcd, phone_num_1, contct_name, setup_date, tax_code, 
                                  inactive_code, update_date)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            ''', [
                row.get('cust_code'),
                row.get('name'),
                row.get('sort_name'),
                row.get('addr_line_1'),
                row.get('addr_city'),
                row.get('addr_state'),
                row.get('addr_postcd'),
                row.get('phone_num_1'),
                row.get('contct_name'),
                row.get('setup_date'),
                row.get('tax_code'),
                row.get('inactive_code'),
                row.get('update_date')
            ])
            rows_inserted += 1
        
        conn.commit()
    
    conn.close()
    print(f"Loaded {rows_inserted} rows into cust")
    return rows_inserted

def load_imst():
    """Load IMST (Item Master) sample data."""
    csv_path = DATA_DIR / "imst_sample.csv"
    if not csv_path.exists():
        print(f"Warning: {csv_path} not found")
        return 0
    
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    
    cursor.execute("DELETE FROM imst")
    
    with open(csv_path, 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f, delimiter=',')
        
        rows_inserted = 0
        for row in reader:
            cursor.execute('''
                INSERT INTO imst (item_code, descr, short_descr, item_cat, matl_type,
                                  order_uom, price_uom, taxble_code, print_on_tkt_flag,
                                  const_flag, update_date)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            ''', [
                row.get('item_code'),
                row.get('descr'),
                row.get('short_descr'),
                row.get('item_cat'),
                row.get('matl_type'),
                row.get('order_uom'),
                row.get('price_uom'),
                row.get('taxble_code'),
                row.get('print_on_tkt_flag'),
                row.get('const_flag'),
                row.get('update_date')
            ])
            rows_inserted += 1
        
        conn.commit()
    
    conn.close()
    print(f"Loaded {rows_inserted} rows into imst")
    return rows_inserted


def _load_csv_to_table(table_name: str, csv_path: Path) -> int:
    if not csv_path.exists():
        print(f"Warning: {csv_path} not found")
        return 0

    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()

    cursor.execute(f"DELETE FROM {table_name}")

    with open(csv_path, 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f, delimiter=',')

        columns = reader.fieldnames
        quoted_columns = [f'"{c}"' for c in columns]
        placeholders = ','.join(['?' for _ in columns])

        insert_sql = f"INSERT INTO {table_name} ({','.join(quoted_columns)}) VALUES ({placeholders})"

        rows_inserted = 0
        for row in reader:
            values = [None if v == "(null)" else v for v in row.values()]
            cursor.execute(insert_sql, values)
            rows_inserted += 1

        conn.commit()

    conn.close()
    print(f"Loaded {rows_inserted} rows into {table_name}")
    return rows_inserted


def load_itrn():
    """Load ITRN (Invoice Transactions File) sample data."""
    return _load_csv_to_table("itrn", ITRN_CSV_PATH)


def load_tick():
    """Load TICK (Ticket Header) sample data."""
    return _load_csv_to_table("tick", TICK_CSV_PATH)


def load_tktl():
    """Load TKTL (Ticket Line) sample data."""
    return _load_csv_to_table("tktl", TKTL_CSV_PATH)


def load_ordr():
    """Load ORDR (Order Header) sample data."""
    return _load_csv_to_table("ordr", ORDR_CSV_PATH)

def show_stats():
    """Show database stats."""
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    
    print("\n=== Database Statistics ===")
    
    # ORDL stats
    cursor.execute("SELECT COUNT(*) FROM ordl")
    count = cursor.fetchone()[0]
    print(f"ORDL rows: {count}")
    
    # TKTC stats
    cursor.execute("SELECT COUNT(*) FROM tktc")
    count = cursor.fetchone()[0]
    print(f"TKTC rows: {count}")
    
    # PLNT stats
    cursor.execute("SELECT COUNT(*) FROM plnt")
    count = cursor.fetchone()[0]
    print(f"PLNT rows: {count}")
    
    # CUST stats
    cursor.execute("SELECT COUNT(*) FROM cust")
    count = cursor.fetchone()[0]
    print(f"CUST rows: {count}")
    
    # IMST stats
    cursor.execute("SELECT COUNT(*) FROM imst")
    count = cursor.fetchone()[0]
    print(f"IMST rows: {count}")

    # ITRN stats
    cursor.execute("SELECT COUNT(*) FROM itrn")
    count = cursor.fetchone()[0]
    print(f"ITRN rows: {count}")

    # TICK stats
    cursor.execute("SELECT COUNT(*) FROM tick")
    count = cursor.fetchone()[0]
    print(f"TICK rows: {count}")

    # TKTL stats
    cursor.execute("SELECT COUNT(*) FROM tktl")
    count = cursor.fetchone()[0]
    print(f"TKTL rows: {count}")

    # ORDR stats
    cursor.execute("SELECT COUNT(*) FROM ordr")
    count = cursor.fetchone()[0]
    print(f"ORDR rows: {count}")
    
    # ORDL summary
    cursor.execute('''
    SELECT 
        COUNT(DISTINCT date(order_date)) as days,
        MIN(date(order_date)) as earliest,
        MAX(date(order_date)) as latest,
        ROUND(SUM(delv_qty), 2) as total_delivered,
        ROUND(SUM(order_qty), 2) as total_ordered,
        COUNT(DISTINCT prod_code) as unique_products
    FROM ordl
    ''')
    row = cursor.fetchone()
    print(f"\nORDL Summary (January 2025):")
    print(f"  Date range: {row[1]} to {row[2]} ({row[0]} unique days)")
    print(f"  Total ordered: {row[4]} yards")
    print(f"  Total delivered: {row[3]} yards")
    print(f"  Unique products: {row[5]}")
    
    # TKTC summary
    cursor.execute('''
    SELECT 
        COUNT(DISTINCT date(order_date)) as days,
        MIN(date(order_date)) as earliest,
        MAX(date(order_date)) as latest,
        ROUND(SUM(delv_qty), 2) as total_delivered,
        ROUND(SUM(ext_price_amt), 2) as total_revenue,
        ROUND(SUM(ext_matl_cost_amt), 2) as total_matl_cost,
        COUNT(DISTINCT prod_code) as unique_products
    FROM tktc
    ''')
    row = cursor.fetchone()
    print(f"\nTKTC Summary (January 2021):")
    print(f"  Date range: {row[1]} to {row[2]} ({row[0]} unique days)")
    print(f"  Total delivered: {row[3]} yards")
    print(f"  Total revenue: ${row[4]}")
    print(f"  Total material cost: ${row[5]}")
    print(f"  Unique products: {row[6]}")
    
    # PLNT summary
    cursor.execute('''
    SELECT plant_code, short_name, name, addr_city, addr_state
    FROM plnt
    ORDER BY plant_code
    ''')
    print(f"\n=== Plants ===")
    for code, short, name, city, state in cursor.fetchall():
        location = f"{city}, {state}" if city and state else ""
        print(f"  {code}: {short} - {name.strip()} {location}")
    
    # CUST sample
    cursor.execute('''
    SELECT cust_code, name, addr_city, addr_state
    FROM cust
    WHERE inactive_code IS NULL OR inactive_code = '00'
    ORDER BY name
    LIMIT 10
    ''')
    print(f"\n=== Active Customers (Sample) ===")
    for code, name, city, state in cursor.fetchall():
        location = f"({city}, {state})" if city and state else ""
        print(f"  {code}: {name.strip()} {location}")
    
    # IMST sample - concrete products
    cursor.execute('''
    SELECT item_code, short_descr, item_cat
    FROM imst
    WHERE item_cat LIKE '%30%' OR item_cat LIKE '%32%'
    ORDER BY item_code
    LIMIT 10
    ''')
    print(f"\n=== Products - Concrete Mixes (Sample) ===")
    for code, name, cat in cursor.fetchall():
        print(f"  {code}: {name} (cat: {cat})")
    
    conn.close()

if __name__ == "__main__":
    print("Building Command Alkon Dummy Database\n")
    init_database()
    load_ordl()
    load_tktc()
    load_plnt()
    load_cust()
    load_imst()
    load_itrn()
    load_tick()
    load_tktl()
    load_ordr()
    show_stats()
    print(f"\nDatabase ready: {DB_PATH}")
