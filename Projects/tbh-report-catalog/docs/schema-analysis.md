# Command Alkon Schema Analysis for TBH Report Catalog

**Date:** 2026-02-16  
**Source:** schema_output.md (210 tables analyzed)

## Executive Summary

Based on thorough analysis of the Command Alkon schema, I've identified **15 core tables** required for the TBH Report Catalog. These fall into four categories:

1. **Transactional (Volume/Revenue)** - Where the actual business activity lives
2. **Master/Reference** - Dimension tables for lookups
3. **AR/Financial** - Invoice and accounts receivable data
4. **Lookup/Code** - Supporting reference data

**Key Finding:** `slsd` appears to be a **report-generated or view table** (based on naming convention and field composition). The primary **source of truth** for volume and pricing is the `ordl` + `tktc` + `tktl` combination.

---

## Tier 1: Essential Tables (Required for Plant Performance v1)

### 1. ORDR — Order Header
**Purpose:** Parent record for all orders. Links customer, project, plant, and pricing.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `order_date` | datetime | Period grouping |
| `order_code` | char(12) | Order identifier |
| `cust_code` | char(10) | Customer dimension |
| `ship_cust_code` | char(10) | Shipping customer (if different) |
| `proj_code` | char(12) | Project dimension |
| `price_plant_code` | char(3) | **Plant for pricing** |
| `comp_code` | char(4) | Company dimension |
| `sales_anl_code` | char(3) | Sales analysis category |
| `slsmn_empl_code` | char(12) | Salesperson |
| `zone_code` | char(8) | Delivery zone |

**Relationship:** One ORDR → Many ORDL (line items)

---

### 2. ORDL — Order Lines
**Purpose:** Product-level details per order. **This is your NRMCA price/yard source.**

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `order_date` + `order_code` | PK | Link to ORDR |
| `order_intrnl_line_num` | numeric | Line identifier |
| `prod_code` | char(12) | Product dimension |
| `prod_descr` | char(40) | Product name |
| `prod_cat` | char(6) | Product category |
| `price` | numeric | **Price per unit** |
| `price_uom` | char(5) | Price UOM |
| `order_qty` | numeric | Ordered quantity |
| `delv_qty` | numeric | **Delivered quantity (VOLUME)** |
| `delv_qty_uom` | char(5) | Volume UOM |
| `delv_to_date_qty` | numeric | Running total delivered |

**Critical for NRMCA:** `price` + `delv_qty` = average price per yard calculation

---

### 3. TKTC — Ticket Charges (Transaction Detail)
**Purpose:** Individual ticket line items with pricing and costs.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `order_date` + `order_code` | FK | Link to order |
| `tkt_code` | char(8) | Ticket identifier |
| `prod_code` | char(12) | Product |
| `delv_qty` | numeric | **Delivered quantity** |
| `delv_qty_uom` | char(5) | UOM |
| `ext_price_amt` | numeric | **Extended price (revenue)** |
| `ext_matl_cost_amt` | numeric | **Material cost estimate** |
| `cost` | numeric | Unit cost |
| `order_intrnl_line_num` | numeric | Link to ORDL |

**Note:** This appears to be the actual transaction-level detail. May be the source for `slsd`.

---

### 4. TKTL — Ticket Lines (Batch Detail)
**Purpose:** Actual batched quantities per ticket.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `order_date` + `order_code` + `tkt_code` | PK | Composite key |
| `order_intrnl_line_num` | numeric | Link to ORDL |
| `actl_batch_qty` | numeric | **Actual batch quantity** |
| `cstmry_actl_batch_qty` | numeric | Customary batch qty |

**Relationship:** Links tickets back to order lines for volume reconciliation.

---

### 5. PLNT — Plant Master
**Purpose:** Plant reference data.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `plant_code` | char(3) | **Primary key** |
| `name` | char(40) | Plant full name |
| `short_name` | char(8) | Short code |
| `comp_code` | char(4) | Company |
| `loc_code` | char(4) | Location |

**Normalization Needed:** Plant codes may vary between `ordr.price_plant_code`, `tktc` tables, and GL.

---

### 6. CUST — Customer Master
**Purpose:** Customer dimension.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `cust_code` | char(10) | **Primary key** |
| `name` | char(40) | Customer name |
| `sort_name` | char(8) | Short name |
| `ca_sales_anl_code` | char(3) | Sales analysis (per plant type) |
| `ca_slsmn_empl_code` | char(12) | Default salesperson |

---

### 7. PROJ — Project Master
**Purpose:** Project/jobsite dimension.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `cust_code` + `proj_code` | PK | Composite key |
| `proj_name` | char(40) | Project name |
| `est_qty` | numeric | Estimated quantity |
| `po` | char(24) | PO number |
| `cust_job_num` | char(24) | Customer job number |
| `ca_slsmn_empl_code` | char(12) | Project salesperson |

---

### 8. IMST — Item Master
**Purpose:** Product/material dimension.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `item_code` | char(12) | **Primary key** |
| `descr` | char(40) | Description |
| `short_descr` | char(16) | Short name |
| `item_cat` | char(6) | **Item category** (concrete type) |
| `matl_type` | char(1) | Material type |
| `batch_code` | char(12) | Mix design code |

---

## Tier 2: AR/Financial Tables (For Revenue Reconciliation)

### 9. ARTB — AR Balance
**Purpose:** Customer balances by item/invoice.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `cust_code` + `item_ref_code` | PK | Composite |
| `plant_code` | char(3) | Plant |
| `proj_code` | char(12) | Project |
| `trans_date` | datetime | Transaction date |
| `sales_amt` | numeric | **Sales amount** |
| `curr_bal_amt` | numeric | Current balance |
| `slsmn_empl_code` | char(12) | Salesperson |

---

### 10. ITRN — Invoice Transactions
**Purpose:** Detailed invoice/payment transactions.

**Key Fields for Reporting:**
| Field | Type | Reporting Use |
|-------|------|---------------|
| `batch_date` + `batch_num` + `batch_seq` | PK | Composite |
| `cust_code` | char(10) | Customer |
| `trans_type` | numeric | Transaction type code |
| `trans_date` | datetime | Date |
| `pretax_amt` | numeric | **Pre-tax amount** |
| `plant_code` | char(3) | Plant |
| `proj_code` | char(12) | Project |
| `invc_code` | char(12) | Invoice number |
| `ca_qty`/`cb_qty`/`cc_qty`/`cd_qty` | numeric | Quantities by prod line |
| `cost_amt` | numeric | Cost amount |

**Note:** `trans_type` likely indicates invoice vs payment vs adjustment.

---

## Tier 3: Lookup/Reference Tables

### 11. EMPL — Employee Master
**Purpose:** Salesperson, driver, batcher reference.

**Key Fields:**
- `empl_code` (PK)
- `name`
- `slsmn_flag` (is salesperson)
- `driv_flag` (is driver)

---

### 12. ICAT — Item Category
**Purpose:** Product category descriptions.

**Key Fields:**
- `item_cat` (PK)
- `descr`
- `matl_type`

---

## Tier 4: Investigate/Clarify

## Decision: Use SLSD as Primary Source

**Rationale from Matt:**
> "Matching the Command reports will be a test that the board will use for the reporting that we provide."

Even if `slsd` is populated by a Command report process, it represents the **authoritative view** that the board expects to see. Using `slsd` ensures our reports reconcile to their existing reports.

**Approach:**
- **Primary:** `slsd` for volume, revenue, and estimated costs
- **Validation:** Source tables (`ORDL`, `TKTC`) for cross-checking
- **Reconciliation:** Document variances between `slsd` and source tables

**Benefits:**
1. Board acceptance — reports match their existing Command outputs
2. Simplicity — single table vs complex joins
3. Audit trail — if `slsd` is wrong, the issue is in Command's report logic, not our extraction

---

## Updated Table Priority

### Phase 1: Core Reporting (Plant Performance v1)
1. **SLSD** — Primary source for volume, revenue, costs
2. **PLNT** — Plant names and details
3. **CUST** — Customer dimension
4. **IMST** — Product dimension

### Phase 2: Validation & Drill-down
5. **ORDR** — Order headers (for project, zone analysis)
6. **ORDL** — Order lines (validate pricing)
7. **TKTC** — Ticket charges (validate costs)
8. **PROJ** — Project details

---

## Table Relationships Summary

```
ORDR (Order Header)
  │
  ├──► ORDL (Order Lines) ──► IMST (Product)
  │      │
  │      └──► TKTC (Ticket Charges) ──► PLNT (Plant)
  │             │
  │             └──► TKTL (Ticket Lines/Batch)
  │
  ├──► PROJ (Project) ──► CUST (Customer)
  │
  └──► ARTB (AR Balance) ◄── ITRN (Invoice Transactions)
```

---

## Recommended Dummy Data Priority

### Phase 1: Core Volume/Revenue (Plant Performance v1)
Based on decision to use `slsd` as primary source:

1. **SLSD** — Sales detail records spanning 2-3 months (200-400 rows)
   - Include multiple plants
   - Include various products
   - Include different customers
   - Cover complete months for period reporting

2. **PLNT** — All plants (likely < 20 rows)

3. **CUST** — Representative customers referenced in SLSD (10-20 rows)

4. **IMST** — Active products/mixes referenced in SLSD

### Phase 2: Validation & Drill-down
5. **ORDR** — Order headers for orders in SLSD sample
6. **ORDL** — Order lines for validation
7. **TKTC** — Ticket charges for cost validation
8. **PROJ** — Projects referenced in SLSD

### Phase 3: Financial Reconciliation
9. **ARTB** — AR balances for same customers
10. **ITRN** — Invoice transactions for same period

### Phase 4: Dimensions
11. **EMPL** — Salespeople, drivers referenced
12. **ICAT** — Item categories

---

## Open Questions for You

1. **SLSD Status:** ✅ DECISION — Use `slsd` as primary source since board will compare against Command reports

2. **Plant Coding:** In `ORDR`, you have `price_plant_code`. In `TKTC`, is there a `plant_code` field? Are they always the same?

3. **Volume Source:** ✅ DECISION — Use `slsd.delv_qty` as primary (matches Command reports)

4. **Pricing Source:** NRMCA average price per yard — is this:
   - `ORDL.price` (order line price)
   - `TKTC.ext_price_amt / TKTC.delv_qty` (ticket calculated)
   - Or derived elsewhere?

5. **Cost Data:** You mentioned `ext_matl_cost_amt` in `TKTC` — is this populated and accurate enough for operational reporting? In `slsd`, we have `ext_matl_cost_amt` — is this the same data?

---

## Files to Update

Once you provide sample data, I'll create:
- `schemas/command_alkon/` — Table definitions
- `test-data/` — CSV fixtures for testing
- `docs/data-dictionary.md` — Field definitions and business rules
