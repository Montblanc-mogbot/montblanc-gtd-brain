# Project: TBH Report Catalog

- **Created:** 2026-02-16
- **Status:** Active
- **Outcome (what done looks like):**
  - Normalized reporting architecture spanning Command Alkon (Dispatch) and GL (Accounting)
  - Layered data pipeline (Extract → Normalize → Analyze → Report)
  - Clear distinction between operational and financial truth
  - CFO-ready executive reports + drillable operations reports
  - Handoff-ready documentation for stepping into CFO role

## Context
- **Command Alkon** (Dispatch): Volume, revenue, estimated costs via `slsd` table
- **GL Database** (Accounting): Actual expenses, journal entries
- **Key Tables Identified:**
  - `slsd` — Sales detail (volume, revenue, estimated costs by plant)
  - `plnt` — Plant master (names, codes)
  - `tkt`/`tktd` — Ticket header/detail
  - `itrn`/`artb` — Invoice/AR transactions
- Current treasurer isn't focused on reporting/analytics
- Matt stepping into CFO role needs clear, trustworthy data

## Sample Data Available
- **SLSD**: 1000 rows (March 1-4, 2025)
  - 6 plants, 70 customers
  - 6,085 yards, $363,250 revenue
- **Database**: SQLite dummy at `data/command_alkon_dummy.db`

## Current Implementation

### ✅ Completed
1. **Dummy Database** (`data/command_alkon_dummy.db`)
   - SQLite database with SLSD sample data
   - Python build script: `scripts/sqlite/build_dummy_db.py`

2. **SQLite Extractor** (`src/Tbh.Extract/Implementations/`)
   - `SqliteCommandAlkonExtractor` - reads from dummy DB
   - Maps all SLSD columns to C# models

3. **Plant Performance Builder** (`src/Tbh.Analytics/Builders/`)
   - Groups data by plant and month
   - Calculates: volume, revenue, material/haul/overhead costs
   - Computes contribution margin and margin %

4. **Excel Generator** (`src/Tbh.Reports/Generators/`)
   - `PlantPerformanceExcelGenerator` using EPPlus
   - Formatted with headers, totals row, currency formatting

5. **Demo Program** (`src/Tbh.ReportCatalog/Program.cs`)
   - Connects to dummy database
   - Extracts March 2025 data
   - Generates Plant Performance analytics
   - Exports to Excel

### 🔄 Next Actions

- [ ] #nextaction #project/tbh-report-catalog Get additional table samples:
  - PLNT (plant master with names)
  - CUST (customer master)
  - IMST (item master)
  - TKTC (ticket costs - if different from SLSD)
- [ ] #nextaction #project/tbh-report-catalog Run `scripts/run-plant-performance.sh` to generate first report
- [ ] #nextaction #project/tbh-report-catalog Validate SLSD data matches Command's native reports
- [ ] #nextaction #project/tbh-report-catalog Create GL database schema extractor

### 📁 Key Files

```
Projects/tbh-report-catalog/
├── data/
│   ├── command_alkon_dummy.db     # SQLite dummy database
│   └── slsd_sample.csv            # Raw sample data (tab-delimited)
├── scripts/
│   ├── sqlite/
│   │   └── build_dummy_db.py      # Rebuilds dummy DB from CSV
│   └── run-plant-performance.sh   # Build & run demo
├── src/
│   ├── Tbh.Extract/
│   │   └── Implementations/
│   │       └── SqliteCommandAlkonExtractor.cs
│   ├── Tbh.Analytics/
│   │   └── Builders/
│   │       └── PlantPerformanceBuilder.cs
│   └── Tbh.Reports/
│       └── Generators/
│           └── PlantPerformanceExcelGenerator.cs
```

## Schema Notes

### Command Alkon — Key Tables

**slsd (Sales Detail)** — Primary source for Plant Performance
```
ship_plant_code    char(3)      -- Plant that shipped
tkt_date           datetime     -- Ticket date (for month grouping)
delv_qty           numeric      -- Volume delivered (yards)
delv_qty_uom       char(5)      -- Unit of measure
ext_price_amt      numeric      -- Extended price (revenue)
ext_matl_cost_amt  numeric      -- Estimated material cost
haul_amt           numeric      -- Haul charges
haul_cost_amt      numeric      -- Estimated haul cost
ovhd_cost_amt      numeric      -- Overhead allocation
```

**plnt (Plant Master)**
```
plant_code         char(3)      -- Primary key
name               char(40)     -- Full plant name
short_name         char(8)      -- Short code
comp_code          char(4)      -- Company
loc_code           char(4)      -- Location code
```

**tkt (Ticket Header)**
```
tkt_date           datetime     -- Ticket date
tkt_code           char(8)      -- Ticket number
plant_code         char(3)      -- Plant
order_date         datetime     -- Order date
order_code         char(12)     -- Order number
```
