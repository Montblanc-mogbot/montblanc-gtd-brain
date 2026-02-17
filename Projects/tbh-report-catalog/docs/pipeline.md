# TBH Report Catalog — Data Pipeline (Draft)

Goal: produce **stable, auditable analytical CSVs** (each answers one business question) from **narrow normalized CSVs**, then generate reports.

## Pipeline Overview (layers)

### Layer 0 — Source exports (raw)
**What it is:** CSV extracts from Command Alkon (and later GL/fuel/materials systems).

**Rule:** we do not “fix” business meaning here; we only preserve what the source says.

---

### Layer 1 — Dummy DB (for development)
**What it is:** a local SQLite database used to iterate quickly.

- Current DB path (repo): `data/command_alkon_dummy.db`
- Notes:
  - If source exports are row-limited, analytics will be incomplete (e.g., TICK/TKTL cutting off mid-month).

---

### Layer 2 — Normalized CSVs (stable, narrow)
**What it is:** cleaned, column-stable CSVs with minimal fields required by downstream analytics.

**Design principles**
- Narrow + stable schemas.
- Explainable to an auditor in plain English.
- Avoid report-specific logic (filters/joins) in normalization.

**Output folder:** `normalized/`

**Current outputs (January 2025 window uses prefix `202501`)**

#### `YYYYMM Plants.csv`
Columns:
- `plant_code`
- `short_name`
- `name`
- `location`

#### `YYYYMM Customers.csv`
Columns:
- `cust_code`
- `name`
- `city`
- `state`

#### `YYYYMM Items.csv`
Columns:
- `item_code`
- `short_descr`
- `descr`
- `item_cat`
- `matl_type`

#### `YYYYMM InvoiceTransactions.csv` (ITRN)
Columns:
- `trans_date`
- `invc_code`
- `trans_type`
- `cust_code`
- `pretax_amt`
- `tax_amt`
- `pmt_amt`
- `check_amt`

#### `YYYYMM Tickets.csv` (TICK)
Columns:
- `order_date`
- `order_code`
- `tkt_code`
- `tkt_date`
- `ship_plant_code`
- `remove_rsn_code`  *(exclusion flag: non-empty means removed/voided)*
- `invc_flag`
- `invc_code`

#### `YYYYMM TicketLines.csv` (TKTL)
Columns:
- `order_date`
- `order_code`
- `tkt_code`
- `order_intrnl_line_num`
- `ship_plant_code`
- `delv_qty`
- `delv_qty_uom`
- `ext_price_amt`

#### `YYYYMM Orders.csv` (ORDR)
Columns:
- `order_date`
- `order_code`
- `prod_line_code` *(currently often `CC` in sample data; may not segment much)*
- `cust_code`
- `cust_name`
- `proj_code`

#### Reference table (pending normalization)
`UOMS` is now present in the dummy DB. If we choose to normalize it, it becomes:
- `YYYYMM Uoms.csv` (or a non-dated `Uoms.csv` since it’s reference)
- keys: `uom`, `abbr`, `descr`, etc.

---

### Layer 3 — Analytical CSVs (business-question datasets)
**What it is:** derived datasets with explicit rules (filters, joins, aggregations). Each CSV should be:
- tied to a clear business question
- reproducible from normalized inputs
- testable via reconciliation checks

**Output folder:** `analytics/`

#### A1) `YYYYMM DispatchPlantDay.csv`
**Question:** “How much did we deliver (qty + $) by plant each day?”

**Mechanism:**
- input: `NormalizedTicketLine` (currently)
- group by `order_date` + `ship_plant_code`
- sum `delv_qty`, sum `ext_price_amt`

**Known improvement needed:** join to `Tickets.csv` and exclude removed tickets via `remove_rsn_code`.

#### A2) `YYYYMM DispatchPlantMonth.csv`
**Question:** “How much did we deliver by plant for the month?”

**Mechanism:**
- input: `NormalizedTicketLine` (currently)
- group by year/month from `order_date` + `ship_plant_code`

**Known improvement needed:** same removal filter + (optional) UOM-based concrete-only volume.

#### A3) `YYYYMM DispatchVsAR_ByInvoice.csv`
**Question:** “Do dispatch-delivered totals reconcile to AR totals per invoice?”

**Mechanism:**
- build dispatch revenue per `invc_code` using TKTL joined to TICK mapping `tkt_code -> invc_code`
- build AR totals from ITRN (`trans_type` 11/21)
- output difference

#### A4) `YYYYMM DispatchLoadsVolumeByDayPlant_ProductLine_Uom.csv` *(sanity-check)*
**Question:** “Loads and volume by day by plant, split by UOM (and product line when useful).”

**Mechanism:**
- join TKTL → TICK to exclude removed tickets (`remove_rsn_code`)
- join to ORDR for `prod_line_code`
- group by `tkt_date` (preferred) + `ship_plant_code` + `prod_line_code` + `delv_qty_uom`
- `loads` = distinct tickets in group
- `concrete_delv_qty` = sum(delv_qty) only for concrete UOM set (currently {`40003`,`40005`,`CY`,`CYARD`})

**Purpose:** debugging/validation; may not be a “forever” analytical dataset.

---

## Reports (Excel)

### R1) Plant Performance (legacy demo)
Current output is still ORDL-backed and will remain unreliable until we switch it to dispatch-based truth (TICK/TKTL + costs).

### R2) Dispatch/Billing Verification Pack
Uses dispatch + AR reconciliation datasets.

---

## “One-at-a-time” roadmap (recommended order)

1) **Dispatch truth datasets** (TICK/TKTL) with:
   - removal filtering (TICK.remove_rsn_code)
   - UOM-based concrete volume
   - UOM leak-check summary

2) **Plant Performance dataset (monthly)**
   - Volume + revenue from dispatch
   - Materials/haul/fuel costs once we have normalized sources

3) **Customer profitability datasets**
   - revenue + yards + margin by customer (requires item/category and cost allocation method)

Each new analytical CSV should ship with: definition, inputs, filters, join keys, and reconciliation checks.
