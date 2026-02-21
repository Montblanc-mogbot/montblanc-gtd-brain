# Project: TBH Report Catalog (Command Alkon → CFO Reporting)

- **Created:** 2026-02-16
- **Status:** Active
- **Primary goal:** A stable, auditable reporting catalog that can reconcile **Dispatch → AR → GL** and produce CFO-ready packs.

## 0) Guiding Principles (the “layers”)

1) **Extract (Layer 1 / Raw)**
   - “What is in the system.”
   - No business logic filtering.
   - Output is raw, table-shaped CSV extracts.

2) **Normalize (Layer 2 / Auditable transforms)**
   - Only transformations that can be explained to auditors.
   - Examples: trimming, standardizing keys, excluding removed tickets, mapping codes → descriptions via reference tables.
   - Output is narrow, well-documented “normalized CSVs” that drive analytics.

3) **Analytics (Layer 3 / One business question per dataset)**
   - Each analytic answers exactly one question.
   - Should not need to re-apply normalization rules.

4) **Reports (Layer 4 / Presentation + exception hunting)**
   - Excel packs for CFO review.
   - Highlight mismatches, missing charges, anomalies.

---

## 1) Current Access (Local Dummy DB)

**SQLite dummy DB:** `data/command_alkon_dummy.db`

Tables currently present (row counts):
- `plnt`: 10
- `cust`: 4,187
- `imst`: 2,315
- `uoms`: 63
- `tick`: 4,861
- `tktl`: 4,914
- `tktc`: 9,357
- `ordr`: 2,522
- `ordl`: 2,803
- `itrn`: 3,778
- `artb`: 1,764
- `gldt`: 16,078

**Not yet present (but likely required for full invoice reconciliation):**
- `TLAP` (Ticket Line Associated Products) – fibers/admixtures
- `TLAC` (Ticket Line Charges)
- `TKTX` (Ticket Taxable Amounts)
- (Any other “T*” tables needed once we see discrepancies)

> Note: these missing tables must be exported from Command Alkon off-hours, then imported into the dummy DB.

---

## 2) Pipeline — CURRENT state vs END state

### 2.1 Extract (Layer 1)

**Current**
- Production MSSQL export script (SELECT-only, chunked IN-lists):
  - `tools/montblanc_export_sqlalchemy_select_only.py`
- Dummy DB build/import:
  - `scripts/sqlite/build_dummy_db.py`
- Raw coverage in dummy DB includes: TICK/TKTL/TKTC/ORDR/ORDL/ITRN/ARTB/GLDT + reference tables.

**End state**
- Raw extracts (CSV) for all required dispatch/billing tables, including:
  - TICK, TKTL, TKTC, ORDR, ORDL
  - **TLAP, TLAC, TKTX** (and any other required “T*” tables)
  - ITRN, ARTB, GLDT
  - Reference: PLNT, CUST, IMST, UOMS
- A repeatable “month window” extractor that can be run off-hours.
- A manifest/log per run: extracted tables, row counts, date window, checksum.

### 2.2 Normalize (Layer 2)

**Current**
- Removed tickets excluded:
  - `Tickets.csv` excludes `remove_rsn_code` not blank.
  - `TicketLines.csv` excludes lines for removed tickets.
- UOM normalization:
  - Ticket line UOM codes are mapped to UOM *descriptions* (via `UOMS`).
- Product line scrub:
  - `prod_line_code` removed from normalized Orders output (not informative here).

**End state**
- Normalized datasets are the single source for analytics:
  - `NormalizedTickets.csv` (one row per ticket)
  - `NormalizedTicketLines.csv` (TKTL)
  - `NormalizedTicketCharges.csv` (TKTC)
  - `NormalizedTicketAssociatedProducts.csv` (TLAP)
  - `NormalizedTicketLineCharges.csv` (TLAC)
  - `NormalizedTicketTaxableAmounts.csv` (TKTX)
- **Derived normalized rollups** (auditable sums):
  - `NormalizedTicketTotals.csv` (one row per ticket, with bucketed totals)
  - Optional: `NormalizedInvoiceTotalsFromDispatch.csv` (invoice-level rollup from ticket totals)
- All normalized datasets use stable keys:
  - Ticket composite key = `(order_date, order_code, tkt_code)`

### 2.3 Analytics (Layer 3)

**Current analytics produced**
- `DispatchPlantDay.csv`
  - day, plant, **quantity (concrete yards)**, revenue, ticket_count, unique_truck_count
- `DispatchVsAR_ByInvoice.csv` (ITRN-based)
  - invoice_code, dispatch_revenue, ar_total, difference
- `DispatchVsAR_ByInvoice_ARTB.csv` (ARTB-based)
  - invoice_code, dispatch_revenue, artb_sales, artb_tax, artb_total, difference
- `DispatchUomSummary.csv`
  - now filtered to **non-concrete UOMs only** (diagnostic)

**End state analytics (target set)**
- Dispatch operations:
  - Dispatch Plant Day (concrete yards + revenue + loads + trucks)
- Dispatch → AR reconciliation:
  - Dispatch vs AR by invoice (dispatch pretax vs AR pretax/tax/total)
  - Include breakdowns for why differences occur (missing charges, removed tickets, unmapped lines)
- Non-concrete revenue:
  - “Non-Concrete Products” analytic that groups by product/description (not just UOM), using TKTC/TLAC/TLAP.

> Key requirement: Dispatch totals must include all dispatch-side revenue components (TKTL + TKTC + TLAC + TLAP), with tax handled separately (TKTX).

### 2.4 Reports (Layer 4)

**Current**
- `reports/YYYYMM DispatchBilling Verification Pack.xlsx`
- Plant Performance demo output (still legacy ORDL-backed for now)

**End state**
- CFO-ready monthly packs:
  - Dispatch/Billing verification pack (exceptions-focused)
  - Plant Performance pack (volume/revenue; add costs later)
  - GL tie-out (batch-key driven via ITRN→GLDT)

---

## TODO

### NEXT ACTION
- [x] #nextaction #project/tbh-report-catalog Hook up OutOfStateZone analytic to zone mapping + fallback city-by-zone list — DONE: `IftaOutOfZoneBuilder` reads `data/ifta_config.json`, `data/out_of_state_zones.csv`, `data/fallback_city_by_zone.csv`
- [x] #nextaction #project/tbh-report-catalog Update dispatch invoice totals to include TKTC + (later) TLAP/TLAC — DONE: dispatch invoice rollup now sums NormalizedTicket.TicketDispatchTotalAmount (TKTL+TKTC). Commit: 768cc36
- [x] #nextaction #project/tbh-report-catalog Replace current UOM-only diagnostic with “Non-Concrete Products” analytic (product name/description) — DONE: removed DispatchUomSummary output from pipeline; use NonConcreteProducts_* analytics instead. Commit: e8da4b4

### WAITING
- (Moved to `Inbox/waiting-for.md`)

### CFO report backlog (build into Layer 4)

> For each report: implement the report generator, run it for a real month window, and summarize the results (key takeaways + exceptions).

1) **Dispatch/Billing Verification Pack** (exceptions-focused)
- [x] #nextaction #project/tbh-report-catalog Implement report: Dispatch/Billing Verification Pack (Excel generator + wiring) — DONE: `DispatchCfoPackExcelGenerator` generates pack; wired in `PipelineRunner` to output `{prefix} DispatchBilling Verification Pack.xlsx`
- [x] #nextaction #project/tbh-report-catalog Run report: Dispatch/Billing Verification Pack (month window) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_053734_202501/reports/202501 DispatchBilling Verification Pack.xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Dispatch/Billing Verification Pack (exceptions + action items) — DONE (dummy DB run 202501): DispatchVsAR_ByInvoice had 724 invoices; median |diff|=$176.66, mean |diff|=$364.64; 697/724 were negative (dispatch < AR). Largest deltas: 1482656 (-$7,792.06), 1483226 (-$4,126.70), 1483300 (-$3,832.50), 1483083 (-$3,322.08), 1482999 (-$3,146.16). Suggests missing components beyond TKTL+TKTC (likely TLAP/TLAC and/or tax handling) and/or invoice-level adjustments/credits not represented on dispatch side yet. Output run: `runs/20260221_053734_202501/`

2) **Dispatch → AR Reconciliation (By Invoice)** (ITRN-based)
- [x] #nextaction #project/tbh-report-catalog Implement report: Dispatch→AR Recon By Invoice (ITRN) — DONE: added `DispatchVsArReconByInvoiceExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} DispatchVsAR Recon By Invoice (ITRN).xlsx`. Commit: 62a193b
- [x] #nextaction #project/tbh-report-catalog Run report: Dispatch→AR Recon By Invoice (ITRN) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_070726_202501/reports/202501 DispatchVsAR Recon By Invoice (ITRN).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Dispatch→AR Recon By Invoice (top deltas + suspected causes) — DONE (dummy DB run 202501): 724 invoices; median |diff|=$176.66; 55 invoices with |diff|>$1,000; diffs overwhelmingly negative (697/724). Top deltas: 1482656 (-$7,792.06), 1483226 (-$4,126.70), 1483300 (-$3,832.50), 1483083 (-$3,322.08), 1482999 (-$3,146.16). Also 6 invoices where AR total=0 but dispatch≠0 (includes 3 with negative dispatch: 1483668, 1484731, 1484729). Suspected causes: dispatch still missing invoice components (TLAP/TLAC/etc), tax comparison (AR includes tax; dispatch is pretax), and credit/adjustment or invoice-linking edge cases for AR=0/negative dispatch scenarios. Run dir: `runs/20260221_070726_202501/`

3) **Dispatch → AR Reconciliation (By Invoice)** (ARTB-based)
- [x] #nextaction #project/tbh-report-catalog Implement report: Dispatch→AR Recon By Invoice (ARTB) — DONE: added `DispatchVsArtbReconByInvoiceExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} DispatchVsAR Recon By Invoice (ARTB).xlsx`. Commit: c31092f
- [x] #nextaction #project/tbh-report-catalog Run report: Dispatch→AR Recon By Invoice (ARTB) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_083721_202501/reports/202501 DispatchVsAR Recon By Invoice (ARTB).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Dispatch→AR Recon By Invoice (ARTB) (top deltas + suspected causes) — DONE (dummy DB run 202501): 724 invoices; median |diff|=$176.66; 55 invoices with |diff|>$1,000; diffs overwhelmingly negative (697/724). Top deltas mirror ITRN run: 1482656 (-$7,792.06), 1483226 (-$4,126.70), 1483300 (-$3,832.50), 1483083 (-$3,322.08), 1482999 (-$3,146.16). Also 6 invoices where ARTB total=0 but dispatch≠0 (3 with negative dispatch: 1483668, 1484731, 1484729). Suspected causes: missing dispatch components (TLAP/TLAC/etc), tax basis mismatch (ARTB total includes tax), and credit/adjustment or invoice-linking edge cases. Run dir: `runs/20260221_083721_202501/`

4) **Plant Performance (Month)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Plant Performance (Month) — DONE: added dispatch-based `PlantPerformanceMonthExcelGenerator` (uses DispatchPlantMonth analytic) and wired in `PipelineRunner` to emit `{prefix} Plant Performance (Month).xlsx`. Commit: 4a624d7
- [x] #nextaction #project/tbh-report-catalog Run report: Plant Performance (Month) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_100721_202501/reports/202501 Plant Performance (Month).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Plant Performance (Month) (volume/revenue leaders, trends) — DONE (dummy DB run 202501): Total CY=15,517; total dispatch rev=$2,477,833.87; total loads=1,981. Top by revenue: Plant 4 ($1,116,066.45; 7,076.75 CY; $157.71/CY), Plant 6 ($663,642.07; 4,165.50 CY; $159.32/CY), Plant 3 ($441,718.81; 2,831.75 CY; $155.99/CY), Plant 1 ($243,231.87; 1,443.00 CY; $168.56/CY). Highest $/CY among nonzero-volume plants: Plant 1 ($168.56/CY). Note: some plants show 0 CY but nonzero revenue (likely non-concrete items/UOMs); see NonConcreteProducts_* analytics for detail. Source: `runs/20260221_100721_202501/analytics/202501 DispatchPlantMonth.csv`

5) **Truck / Driver Scorecard (Month)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Truck/Driver Scorecard (Month) — DONE: added `TruckDriverScorecardMonthExcelGenerator` (based on TruckDriverScorecard_MonthTruckDriver analytic) and wired in `PipelineRunner` to emit `{prefix} Truck-Driver Scorecard (Month).xlsx`. Commit: b5f79a2
- [x] #nextaction #project/tbh-report-catalog Run report: Truck/Driver Scorecard (Month) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_113725_202501/reports/202501 Truck-Driver Scorecard (Month).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Truck/Driver Scorecard (Month) (outliers, utilization) — DONE (dummy DB run 202501): 73 trucks. Utilization: mean loads=26.6 (median 28), max 51; mean active days=10.3 (median 11), max 17. Top by loads: truck 430 (51 loads / 17 days ≈3.00/day; 427.75 CY; $68,700.76; plant 6), 423 (49 loads / 15 days ≈3.27/day; 425.75 CY; $70,630.25; plant 4), 420 (47 loads; $63,856; plant 4). Top by revenue: 423 ($70,630.25), 430 ($68,700.76), 417 ($64,093.00). Low avg CY/load outliers (small-load style): 438 (5.66 CY/load; 8 loads; plant 1), 353 (6.64 CY/load; 34 loads; plant 6), 365 (6.70 CY/load; 14 loads; plant 1). High $/CY outliers: 386 ($179.52/CY), 365 ($175.08/CY), 438 ($174.52/CY). No trucks served >=3 unique plants in month (unique_plants max <3). Source: `runs/20260221_113725_202501/analytics/202501 TruckDriverScorecard_MonthTruckDriver.csv`

6) **Time-of-Day Heatmap (Ops)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Time-of-Day Heatmap (Hour×Day×Plant) — DONE: added `TimeOfDayHeatmapHourDayPlantExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} Time-of-Day Heatmap (HourxDayxPlant).xlsx`. Commit: c4c0560
- [x] #nextaction #project/tbh-report-catalog Run report: Time-of-Day Heatmap (Hour×Day×Plant) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_130725_202501/reports/202501 Time-of-Day Heatmap (HourxDayxPlant).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Time-of-Day Heatmap (peaks, staffing implications) — DONE (dummy DB run 202501): Overall peak hours by loads: 09:00 (251), 12:00 (247), 08:00 (243), 11:00 (242), 07:00 (215). Plant 4 dominates peaks (e.g., hour 08:00=101 loads; 09:00=96; 12:00=95; 11:00=93; 07:00=90). Plant 6 secondary (hour 12:00=85; 11:00=79; 08:00=69; 09:00=68). Day-of-week: Friday is busiest (top combos Fri 09:00=92, Fri 12:00=87, Fri 07:00=82). Timestamp coverage is high: 1962/1981 loads (99%) had usable LoadTime/ScheduledLoadTime. Staffing implication: expect heavy dispatch/loading activity 07:00–13:00 with strongest surge 08:00–12:00, especially for Plant 4. Source: `runs/20260221_130725_202501/analytics/202501 TimeOfDayHeatmap_HourDayPlant.csv`

7) **Customer Mix (Month × Plant)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Customer Mix (Month×Plant) — DONE: added `CustomerMixMonthPlantExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} Customer Mix (MonthxPlant).xlsx`. Commit: 0f093a5
- [x] #nextaction #project/tbh-report-catalog Run report: Customer Mix (Month×Plant) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_143726_202501/reports/202501 Customer Mix (MonthxPlant).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Customer Mix (concentration risk, changes) — DONE (dummy DB run 202501): High-volume plants concentration (by revenue share): Plant 6 top customer NVRI01 is 31.3% of rev (top5=51.5%, HHI~1187). Plant 4 top customer JSCC01 is 18.1% (top5=58.0%, HHI~850); next two customers each ~13%. Plant 3 top customer SMIT01 is 16.0% (top5=50.6%, HHI~696). Plant 1 top customer AYER01 is 17.8% (top5=54.7%, HHI~802). Low-volume/non-CY plants (40/42/43/44) are extremely concentrated but represent small dollars and appear to be non-concrete sales (0 CY). Source: `runs/20260221_143726_202501/analytics/202501 CustomerMix_MonthPlant.csv`

8) **Product Mix (Month × Plant)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Product Mix (Month×Plant) — DONE: added `ProductMixMonthPlantExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} Product Mix (MonthxPlant).xlsx`. Commit: 27d84fd
- [x] #nextaction #project/tbh-report-catalog Run report: Product Mix (Month×Plant) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_160725_202501/reports/202501 Product Mix (MonthxPlant).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Product Mix (margin proxy candidates, anomalies) — DONE (dummy DB run 202501): Plant 4 top volume product 3303J (977.5 CY; 13.8% CY; $155.33/CY) and 9462X (870.25 CY; $146/CY); Plant 6 top volume 9143A (523.5 CY; $137.50/CY) and 3303J EXTRSLAB (322.75 CY; $143/CY); Plant 3 dominated by 3332X (490.75 CY; $137.50/CY); Plant 1 top by CY is 9143B (191.5 CY; $147.79/CY). High $/CY candidates (>=20 CY): 1/4783US shotcrete $198.50/CY (58 CY), 6/9545L $195/CY (105 CY), 6/7940X flowfill $180/CY (145.5 CY), 4/3593B 5000# AE $182.50/CY (74.5 CY). Low $/CY (>=20 CY): 3/2122A $128/CY (170.25 CY), 4/9143A ductbank $131/CY (76 CY), 6/9173A $135.50/CY (297.5 CY). Note: product mix revenue is TKTL concrete lines only (excludes TKTC charges), so margin proxies should be compared cautiously. Source: `runs/20260221_160725_202501/analytics/202501 ProductMix_MonthPlant.csv`

9) **Zone Performance (Month)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Zone Performance (Month) — DONE: added `ZonePerformanceMonthExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} Zone Performance (Month).xlsx`. Commit: b55e540
- [ ] #nextaction #project/tbh-report-catalog Run report: Zone Performance (Month)
- [ ] #nextaction #project/tbh-report-catalog Summarize report: Zone Performance (pricing/haul implications)

10) **Project Tracker (Active Projects / Large Jobs)**
- [ ] #nextaction #project/tbh-report-catalog Implement report: Project Tracker
- [ ] #nextaction #project/tbh-report-catalog Run report: Project Tracker
- [ ] #nextaction #project/tbh-report-catalog Summarize report: Project Tracker (growth/decline, top projects)

11) **Invoice Aging + Collections Dashboard**
- [ ] #nextaction #project/tbh-report-catalog Implement report: Invoice Aging + Collections Dashboard
- [ ] #nextaction #project/tbh-report-catalog Run report: Invoice Aging + Collections Dashboard
- [ ] #nextaction #project/tbh-report-catalog Summarize report: Invoice Aging + Collections Dashboard (past-due drivers)

12) **Credit / Adjustment Register (Month)**
- [ ] #nextaction #project/tbh-report-catalog Implement report: Credit/Adjustment Register (from ITRN)
- [ ] #nextaction #project/tbh-report-catalog Run report: Credit/Adjustment Register (from ITRN)
- [ ] #nextaction #project/tbh-report-catalog Summarize report: Credit/Adjustment Register (root causes + approvals)

### DONE

## Validation plan
- Pick 3–5 invoices where dispatch is short vs AR (like 1483341) and trace:
  - TKTL vs TKTC vs (TLAP/TLAC) vs AR (ITRN/ARTB)
  - Identify which table(s) contain the missing revenue components

---

## 4) Key Files / Entry Points

- Pipeline overview: `docs/pipeline.md`
- Table relationships + notes: `docs/schema-analysis.md`
- Export (prod MSSQL, SELECT-only): `tools/montblanc_export_sqlalchemy_select_only.py`
- Dummy DB build: `scripts/sqlite/build_dummy_db.py`
- Runner: `src/Tbh.ReportCatalog/Program.cs`

