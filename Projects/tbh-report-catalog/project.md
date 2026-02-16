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

## Next Actions
- [ ] #nextaction #project/tbh-report-catalog Create C# project skeleton with layered architecture
- [ ] #nextaction #project/tbh-report-catalog Define PlantPerformance analytical dataset model
- [ ] #nextaction #project/tbh-report-catalog Create extraction interfaces (for Matt to implement queries)
- [ ] #nextaction #project/tbh-report-catalog Build CSV normalization pipeline
- [ ] #nextaction #project/tbh-report-catalog Design Excel report template for Plant Performance

## Waiting On
- [ ] #waitingfor #project/tbh-report-catalog Matt: Sample data from `slsd`, `plnt` tables (10-20 anonymized rows)
- [ ] #waitingfor #project/tbh-report-catalog Matt: GL schema (table names for expenses)
- [ ] #waitingfor #project/tbh-report-catalog Matt: Confirm plant coding in GL (separate field or embedded in accounts?)

## Someday / Maybe
- [ ] #someday #project/tbh-report-catalog Automate extraction pipeline (scheduled monthly pulls)
- [ ] #someday #project/tbh-report-catalog Build data quality / reconciliation alerts
- [ ] #someday #project/tbh-report-catalog Griddle integration for interactive operations reports
- [ ] #someday #project/tbh-report-catalog Add Fuel Economics dataset

## Notes / Context
- `slsd` (Sales Detail) has estimated costs — useful for operational reporting, but GL is source of truth for financials
- Reconciliation view will bridge: Command estimates vs GL actuals
- Each analytical dataset answers ONE business question well
- Normalized data must be explainable to an auditor in plain English

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
