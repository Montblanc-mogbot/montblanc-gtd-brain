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

**Next real validation window (selected):** `2025-02-01` → `2025-03-01`

**Why this window**
- Adjacent to the completed 2025-01 dummy validation, so month-over-month comparison is straightforward.
- Small, concrete off-hours ask: one full month rather than a broad historical backfill.
- Lets us validate whether the 2025-01 exception patterns persist once TLAP/TLAC/TKTX are included from a real export.

**Raw exports to request / collect off-hours**
- **Command dispatch/ops**
  - `TICK` — date/key fields: `order_date`, `order_code`, `tkt_code`; invoice linkage/date fields such as `inv_date`, `inv_code`; any removed-ticket flags.
  - `TKTL` — `order_date`, `order_code`, `tkt_code`; line/product/UOM/qty/amount fields.
  - `TKTC` — `order_date`, `order_code`, `tkt_code`; charge code/description/amount fields.
  - `TLAP` — `order_date`, `order_code`, `tkt_code`; associated-product/product-description fields; `ext_price_amt` (or equivalent amount field).
  - `TLAC` — `order_date`, `order_code`, `tkt_code`; line-charge code/description/amount fields.
  - `TKTX` — `order_date`, `order_code`, `tkt_code`; tax basis / taxable amount / tax amount fields.
  - `ORDR`, `ORDL` — keyed by `order_date` + `order_code` for order-level context and line rollups.
- **AR**
  - `ITRN` — invoice key/date fields (`inv_date`, `inv_code`) plus transaction amount/type/posting-date fields.
  - `ARTB` — invoice key/date fields (`inv_date`, `inv_code`) plus sales/tax/total fields.
- **Optional financial tie-out sample**
  - `GLDT` for the same 2025-02 window, with whatever posting/account/date fields are available.

**Join/date expectations for the export request**
- Dispatch-side ticket joins should preserve `order_date` + `order_code` + `tkt_code` across TICK/TKTL/TKTC/TLAP/TLAC/TKTX.
- AR extracts should preserve invoice linkage via `inv_code` (and `inv_date` when available).
- Prefer filtering each table to the **2025-02 business window** using its native transaction/invoice/ticket date column, and include that date column in the extract so the filter basis is auditable.

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

## Thread digest
- last_thread_digest_at: 2026-03-27T12:22-04:00
- 2026-03-27: Project hubs are now the canonical home for project-specific todos and distilled thread memory.
- 2026-03-27: Continue using this hub for requirements, decisions, blockers, and notable thread-derived context rather than relying on chat history alone.
- 2026-03-27: Imported TLAC data into the dummy Command database and wired TLAC through the pipeline. Current position: TLAC primarily belongs in the normalized ticket charge amount (`Tickets.csv.ticket_charge_amt`) as ticket misc charges; the separate `TicketLineCharges.csv` output is useful for audit/debug detail but may not need to be a front-and-center business artifact.
- 2026-03-27: This machine/repo environment is for development, testing, and dummy-data validation only. Real operational pipeline runs and real-data hookups will happen on a separate environment after repo sync (`git pull`) and environment-specific hookup changes.
- 2026-03-27: Real production databases are MySQL and MSSQL. The new runtime-config layer is in place, but true live production support still requires provider-specific extractor/factory work beyond the current sqlite-only implementation.
- 2026-03-30: Source mapping clarified for first real run: **Command = MSSQL**, **TBH AP = MySQL**, **TBH GL = MySQL**. Remaining production-readiness work should target that exact provider mix rather than treating AP/GL as ambiguous.

## TODO

### NEXT ACTIONS (heartbeat-created)

- [ ] #nextaction #waitingfor Matt: Add the Discord thread id/link for this project (paste `channel:<id>` or full thread URL) so heartbeat can post pulses.
- [x] #nextaction Define the next **real month window** to validate (e.g., 2025-02, 2025-03) and list what raw exports are required (tables + date columns) so we can request/collect them off-hours. — DONE: picked **2025-02** as the next real validation window (adjacent to the completed 2025-01 dummy run, keeps month-over-month comparison simple, and is a short off-hours request). Required raw exports captured for request/collection: **Command ops/AR**: TICK (`order_date`, `order_code`, `tkt_code`, `inv_date`, `inv_code`), TKTL (`order_date`, `order_code`, `tkt_code`, line/product/UOM/amount fields), TKTC (`order_date`, `order_code`, `tkt_code`, charge code/amount fields), TLAP (`order_date`, `order_code`, `tkt_code`, ext_price_amt + product/description fields), TLAC (`order_date`, `order_code`, `tkt_code`, charge/amount fields), TKTX (`order_date`, `order_code`, `tkt_code`, tax amount/basis fields), ORDR/ORDL (order-level context keyed by `order_date` + `order_code`), ITRN (`inv_date`, `inv_code`, transaction amount/type/date fields), ARTB (`inv_date`, `inv_code`, sales/tax/total fields); **optional GL tie-out sample**: GLDT for the same 2025-02 window using whatever posting/account/date fields are available. Evidence: updated project hub note below this TODO with the selected window + export checklist.
- [x] #nextaction Add TLAC (ticket line charges) end-to-end: Layer 1 extract → Layer 2 normalize → include in dispatch totals + non-concrete rollups → update recon reports (ITRN/ARTB) to break out TLAC separately. — DONE: imported TLAC CSV into `data/command_alkon_dummy.db` as `tlac`, added extractor/model/normalizer support, wrote normalized `TicketLineCharges.csv`, rolled TLAC into `Tickets.csv.ticket_charge_amt` (TKTC + TLAC), propagated TLAC-aware dispatch charge totals through recon/report flows, updated pipeline inventory docs, and added TLAC unit coverage. Evidence: repo worktree changes in `src/Tbh.Extract/Models/CommandAlkon/TlacRecord.cs`, `src/Tbh.Normalize/CommandAlkonDispatchNormalizer.cs`, `src/Tbh.ReportCatalog/Pipeline/PipelineRunner.cs`, `src/Tbh.ReportCatalog.Tests/Analytics/DispatchTlacTests.cs`; validation: `dotnet test` passed and `dotnet run --project src/Tbh.ReportCatalog -- 2025-01-01 2025-02-01` generated `202501 TicketLineCharges.csv`.
- [x] #nextaction Add an extract run manifest checksum step (CSV row counts + sha256) so month runs are auditable/reproducible. — DONE: added `Sha256` to manifest artifacts, centralized artifact metadata helpers in `src/Tbh.ReportCatalog/Pipeline/PipelineIo.cs`, wired checksum-aware artifact creation across extract/normalized/analytics/report registrations, added unit coverage in `src/Tbh.ReportCatalog.Tests/Pipeline/PipelineIoTests.cs`, and updated `README.md` + `docs/runbook.md`. Evidence: representative run `runs/20260327_143727_202501/manifest.json` now includes `RowCount`, `FileBytes`, and `Sha256`; validation: `dotnet test TbhReportCatalog.sln` and `dotnet run --project src/Tbh.ReportCatalog -- 2025-01-01 2025-02-01`.
- [x] #nextaction Document the real-data operator run contract in repo docs/runbook: live DB connections are the primary inputs, the operator runs one command per month, terminal progress should be human-readable, and outputs should land in a config-defined directory. — DONE: updated `docs/runbook.md` to describe the target production operator contract (config-defined live DB connections + output root, one command per month, human-readable terminal progress, outputs landing in a configured directory) while still preserving the current local-dev SQLite/file workflow on this machine. Evidence: `docs/runbook.md` sections “Intended real-data operator contract” and “Practical real-data workflow”.
- [x] #nextaction Design the real runtime configuration contract for production use: define where live DB connections, output root, enabled sources, and environment-specific settings should live. — DONE: documented the proposed runtime configuration contract in `docs/runbook.md`, including runtime-owned settings (live Command/AP/GL connections, output root, enabled sources, environment label), repo-owned supporting config/mapping files, and the rule that CLI should not require operators to re-specify connection strings or output directories each month. Evidence: `docs/runbook.md` section “Proposed runtime configuration contract”; code-review context from `src/Tbh.ReportCatalog/Program.cs`, `src/Tbh.ReportCatalog/Pipeline/RunContext.cs`, and `src/Tbh.ReportCatalog/Pipeline/PipelineIo.cs` showing what is still hardcoded/local today.
- [x] #nextaction Improve the CLI/operator UX for monthly runs: prefer a month-based entrypoint (`--month YYYY-MM` or wrapper script) over raw start/end dates. — DONE (design/docs): updated `docs/runbook.md` to define the target monthly operator UX as either `./run-month.sh YYYY-MM` or `dotnet run --project src/Tbh.ReportCatalog -- --month YYYY-MM`, explained why month-first UX is preferable, documented the current date-pair CLI behavior, and recommended preserving raw start/end dates for debugging and non-standard windows. Evidence: `docs/runbook.md` section “CLI / operator UX contract”.
- [x] #nextaction Improve terminal progress output so operators can see stage-by-stage status during a live monthly run. — DONE (design/docs): documented the terminal progress contract in `docs/runbook.md`, including recommended operator-visible stage messages (connecting to sources, extracting datasets, normalizing, building analytics, generating reports, writing outputs, completed summary) and final-console summary expectations. Evidence: `docs/runbook.md` section “Terminal progress contract”.
- [x] #nextaction Define and document the output directory contract for production runs (run folder, latest folder, reports, diagnostics, manifests) under a config-defined output root. — DONE: documented the target production output-root contract in `docs/runbook.md`, including `<output-root>/runs/<run-id>/...` immutable snapshots, `<output-root>/latest/...` mutable convenience copies, and the operator expectations for where review should begin (`reports/` + `manifest.json`). Also preserved the current repo-local output behavior as the “today” implementation. Evidence: `docs/runbook.md` sections “Output directory contract” and “Where outputs land today”.
- [x] #nextaction Decide how future optional static inputs (for example fleet schedule/reference files) fit into the runtime contract without replacing live DB connections as the primary source model. — DONE (design/docs): documented the optional static-inputs contract in `docs/runbook.md`. Static files are now explicitly framed as supplemental inputs only, with live DB connections remaining the primary source of truth. Captured rules for acceptable uses, bad uses, and the requirement that runs should clearly state whether supplemental files were loaded, skipped, or missing. Evidence: `docs/runbook.md` section “Optional static inputs contract”.
- [x] #nextaction Document a “refresh dummy DB from raw extracts” playbook (exact commands + expected artifacts) in `docs/pipeline.md`. — DONE: added a dedicated development/test playbook section to `docs/pipeline.md` covering Command/AP/GL dummy DB rebuild inputs, exact rebuild commands, expected output DB artifacts, and the recommended post-rebuild validation flow (`dotnet build`, `dotnet test`, representative month run, inspect `manifest.json` and core outputs). Evidence: `docs/pipeline.md` section “Refresh dummy DB from raw extracts (development/test playbook)”.

### Historical validation utilities against trusted reports #nextaction
- [x] #nextaction Add a **TICK validation report** for month-by-month comparison to trusted historical reports: output **load count** and **quantity** by **day + plant**, using the current dispatch pipeline logic as the first-pass definition and expecting iteration once live-data business rules are observed. — DONE: added explicit analytics artifact `TickValidation_DayPlant.csv` in `src/Tbh.ReportCatalog/Pipeline/PipelineRunner.cs`, sourced from the existing dispatch day/plant rollup (`DispatchAnalyticsBuilders.BuildDispatchPlantDay`) and emitted with validation-oriented columns `day, plant_code, load_count, quantity`. Added focused builder coverage in `src/Tbh.ReportCatalog.Tests/Analytics/TickValidationBuilderTests.cs`. Validation: `dotnet test TbhReportCatalog.sln` passed (22 tests) and `dotnet run --project src/Tbh.ReportCatalog -- --month 2025-01` produced `runs/20260330_095340_202501/analytics/202501 TickValidation_DayPlant.csv`.
- [ ] #nextaction Add a **GLDT validation report** for month-by-month comparison to trusted historical reports: output **trans_amt** by **cost_center + descr_y + acct_code + descr_x**.
- [ ] #nextaction Add an **STXD sales tax validation report** for month-by-month comparison to trusted historical reports: output **taxble_amt + non_taxble_amt + tax_amt** by **tax_code + descr**.

### Production-readiness blockers before first real-data run #nextaction
- [x] #nextaction Implement live database connection/runtime config support so the pipeline can run against real Command/AP/GL sources instead of repo-local dummy DB paths. — DONE (runtime-config layer): added `RuntimeOptions` + loader, `--config` support, `data/runtime.example.json`, expanded `RunContext` with environment/output/source metadata, updated `PipelineRunner` to construct extractors from source descriptors, and preserved backward-compatible local-dev fallback. Evidence: `src/Tbh.ReportCatalog/Configuration/RuntimeOptions.cs`, `RuntimeOptionsLoader.cs`, `Program.cs`, `Pipeline/RunContext.cs`, `data/runtime.example.json`, `src/Tbh.ReportCatalog.Tests/Pipeline/RuntimeOptionsLoaderTests.cs`. **Important limitation:** provider support is still only `sqlite`; true live production DB support for MySQL/MSSQL remains a separate blocker.
- [x] #nextaction Implement config-defined output-root support so real runs write to the intended production output directory instead of repo-local `runs/` + latest folders. — DONE: runtime-config work now supports configurable output roots with immutable runs under `<output-root>/runs/...` and mutable outputs under `<output-root>/latest/...`; local-dev repo-root fallback is preserved when no runtime config is supplied. Evidence: updated runtime config model + `RunContext` output fields, startup/runtime docs in `README.md` and `docs/runbook.md`.
- [x] #nextaction Implement provider-specific live source support for the real production databases: **Command via MSSQL**, **TBH AP via MySQL**, and **TBH GL via MySQL**, replacing the current sqlite-only provider limitation in live environments. — DONE: runtime source factory now creates provider-specific extractors for sqlite/mysql/mssql, ADO-based extractor implementations exist for Command/AP/GL, runtime config loader validates connection-string providers correctly, and solution build/tests pass. Evidence: `src/Tbh.ReportCatalog/Pipeline/RuntimeSourceFactory.cs`, `src/Tbh.Extract/Implementations/MySqlCommandAlkonExtractor.cs`, `src/Tbh.Extract/Implementations/MySqlTbhApExtractor.cs`, `src/Tbh.Extract/Implementations/MySqlTbhGlExtractor.cs`, `src/Tbh.Extract/Implementations/SqlServerCommandAlkonExtractor.cs`, `src/Tbh.ReportCatalog/Configuration/RuntimeOptionsLoader.cs`, `src/Tbh.ReportCatalog.Tests/Pipeline/RuntimeOptionsLoaderTests.cs`; validation: `dotnet build TbhReportCatalog.sln` and `dotnet test TbhReportCatalog.sln` both passed on 2026-03-30.
- [x] #nextaction Implement the month-first operator entrypoint (`--month YYYY-MM` or a wrapper script) for the real run workflow while preserving raw start/end date mode for debugging. — DONE: added built-in `--month YYYY-MM` parsing in `src/Tbh.ReportCatalog/Program.cs`, preserved positional `startDate endDate` support, improved `--help` usage text, added argument-parsing coverage in `src/Tbh.ReportCatalog.Tests/Pipeline/ProgramArgumentParsingTests.cs`, and updated operator docs in `README.md` + `docs/runbook.md` to recommend the built-in CLI for Windows operators rather than requiring a bash wrapper. Validation: `dotnet test TbhReportCatalog.sln` passed (21 tests) and `dotnet run --project src/Tbh.ReportCatalog -- --help` shows the new month-first usage.
- [x] #nextaction Implement operator-visible terminal progress output in code (not just documented expectations) for source connection, extraction, normalization, analytics, report generation, and final output path. — DONE: added stage-oriented console progress in `src/Tbh.ReportCatalog/Pipeline/PipelineRunner.cs` with clear start/completion markers for **Extract + normalize**, **Analytics**, **Reports**, and **Manifest**, plus human-readable detail lines for source extraction, analytics CSV writing, final artifact count, latest output root, and review locations for reports/manifest. Validation: `dotnet build TbhReportCatalog.sln`, `dotnet test TbhReportCatalog.sln`, and `dotnet run --project src/Tbh.ReportCatalog -- --month 2025-01` all passed on 2026-03-30, and the run output now shows ordered stage progress suitable for a Windows terminal operator.
- [x] #nextaction Create a short real-data readiness checklist covering environment config, required secrets/connections, output location, exact run command, first-review reports, and known caveats for the first live run. — DONE: added a dedicated **First real-data run readiness checklist** section to `docs/runbook.md` covering Windows operator setup, runtime config, exact provider mix (**Command=mssql, AP=mysql, GL=mysql**), secrets/connectivity checks, exact `--month YYYY-MM` run command, in-run console verification points, post-run review order, and first-run caveats. Also expanded `data/runtime.example.json` with a production-shaped Windows example and updated `README.md` to point operators to the runbook checklist. Validation: `dotnet build TbhReportCatalog.sln` and `dotnet test TbhReportCatalog.sln` passed on 2026-03-30.

- [x] #nextaction #project/tbh-report-catalog Import Matt-provided GL reference tables (zip + CSV attachments) into a **separate SQLite DB** (NOT the Command dummy DB). — DONE: created standalone GL dummy DB `/home/montblanc/repos/tbh-report-catalog/data/tbh_gl_dummy.db` from `data/gl_inbound_2025/` via `scripts/sqlite/build_gl_dummy_db.py`. Row counts: ap_invoice_dtl 28,772; ap_invoice_hdr 10,634; ap_master 1,569; gl_adjust 3,163; gl_journal 11,860; gl_trans 5,472; gl_desc 718.

#### TBH GL/AP pipeline scaffold (new)

- [x] #nextaction #project/tbh-report-catalog Split the dummy GL/AP exports into two DBs to mirror prod (`tbh_ap` vs `tbh_gl`) and record row counts — DONE: created `/home/montblanc/repos/tbh-report-catalog/data/tbh_ap_dummy.db` + `/home/montblanc/repos/tbh-report-catalog/data/tbh_gl_dummy.db` via `scripts/sqlite/build_tbh_ap_dummy_db.py` + `scripts/sqlite/build_tbh_gl_dummy_db.py`. Row counts: ap_invoice_dtl 28,772; ap_invoice_hdr 10,634; ap_master 1,569; gl_adjust 3,163; gl_journal 11,860; gl_trans 5,472; gl_desc 718.
- [x] #nextaction #project/tbh-report-catalog Wire **TBH AP + GL extractors** into `PipelineRunner` (separate from Command extractor) — DONE: pipeline now detects `data/tbh_ap_dummy.db` + `data/tbh_gl_dummy.db` and writes Layer 1 raw extracts to `runs/.../extract/` (and `extract/` latest), adding artifacts to manifest. Commit: 5b9336f.
  - Outputs: `ApInvoiceHdr_Raw.csv`, `ApInvoiceDtl_Raw.csv`, `ApMaster_Raw.csv`, `GlTrans_Raw.csv`, `GlJournal_Raw.csv`, `GlAdjust_Raw.csv`, `GlDesc_Raw.csv`
- [x] #nextaction #project/tbh-report-catalog Add **Layer 2 normalized CSVs** for TBH AP + GL (typed parsing + trimming; no business logic) — DONE: added `TbhApGlNormalizer` + normalized model records and wired PipelineRunner to write these outputs + add them to manifest. Commit: 3644fa3.
  - AP: `NormalizedApVendors.csv`, `NormalizedApInvoices.csv`, `NormalizedApInvoiceLines.csv`
  - GL: `NormalizedGlDesc.csv`, `NormalizedGlJournalLines.csv`, `NormalizedGlTransactions.csv`, `NormalizedGlAdjustments.csv`
- [x] #nextaction #project/tbh-report-catalog Investigate + document the **GLDESC oddities** (departments vs GL accounts) in `docs/schema-analysis.md`: — DONE: wrote analysis + mapping rules + examples to `/home/montblanc/.openclaw/workspace/docs/schema-analysis.md` (based on dummy DB `/home/montblanc/repos/tbh-report-catalog/data/tbh_gl_dummy.db`).
  - Codes starting with **4**** = departments (observed: 40003, 40004, 40005, 40007, 40010, 40011)
  - Codes starting with **5**** = GL account numbers (e.g. 51010)
  - Documented join/lookup rules: `dept_gldescno = "4" + deptNo.zfill(4)` and `acct_gldescno = "5" + acctNo.zfill(4)`
  - Produced mapping examples + real-row aggregates from `gl_trans`
- [x] #nextaction #project/tbh-report-catalog Implement **GL account classification helpers** (Layer 2.5 “auditable transforms”) — DONE: added `Tbh.Normalize/GlAccountClassifier.cs` (GlDescType + canonical acct rewrite for 50001–50999 based on dept) + unit tests. Commit: 6e02703.
  - `gldesc_type` = Department | Account
  - `dept_code` extraction when applicable
  - `account_code` extraction when applicable
  - `canonical_account_code` for departmentalized ranges (documented rule)
- [x] #nextaction #project/tbh-report-catalog Add first **Layer 3 analytics** for TBH GL (month + YTD) — DONE: added GL analytics builder + outputs written in PipelineRunner (from GL journal lines) and added to manifest. Commit: e97f17b.
  - `GlTrialBalance_Month.csv` (by dept + account)
  - `GlPnL_Month.csv` (bucket by account ranges; start with placeholder mapping)
  - `GlPnL_Ytd.csv`
- [x] #nextaction #project/tbh-report-catalog Add first **Layer 3 analytics** for TBH AP — DONE: added AP analytics builders and wired PipelineRunner outputs + manifest artifacts. Commit: 23fd2dd.
  - `ApSpendByVendor_Month.csv`
  - `ApSpendByGlAccount_Month.csv` (join AP dtl dept/acct to GLDESC when possible)

#### GL/AP + Command blended analytics (value-add)

- [x] #nextaction #project/tbh-report-catalog Add GL/AP analytic: `ApMaterialSchedule_Month.csv` (recon for AP-coded materials) — DONE: added analytics builder `BuildApMaterialScheduleMonth` and pipeline output with flags (missing qty/acct/desc + extreme unit costs). Commit: 0d1881a.
  - Use AP invoice lines joined to AP headers (invoice date window)
  - Group by: vendor + dept + GL acct (+ desc) + unit price proxy
  - Include: total amount, total quantity, implied unit cost (= amount/qty) when qty present
  - Flag: missing qty, missing acct/desc, extreme unit costs
- [x] #nextaction #project/tbh-report-catalog Add GL analytic: `TaxesPayable_Month.csv` (outstanding taxes to pay) — DONE: added config-driven mapping (`data/tax_payable_mapping.json`) + analytics builder + pipeline outputs `TaxesPayable_Month.csv` and `TaxesPayable_Lines_Month.csv` (drilldown). Commit: e755427.
  - Start with rule-based buckets via GL account ranges + gldesc lookup
  - Output totals by tax type + dept; include drilldown list of contributing journal lines
  - Keep mapping table auditable (csv/json config)
- [x] #nextaction #project/tbh-report-catalog Add blended analytic: `CostPerCubicYard_MonthPlant.csv` — DONE: added config-driven bucket mapping (`data/cost_per_cy_mapping.json`) + blended builder using GL journal lines ÷ dispatch concrete CY, and wrote pipeline output + manifest artifact. Commit: d273a66.
  - Numerator: selected cost buckets from GL/AP (materials, fuel, etc.)
  - Denominator: dispatch concrete CY from Command (DispatchPlantMonth)
  - Output: cost/CY by plant + by bucket; include notes about timing mismatch + cutoff assumptions
- [x] #nextaction #project/tbh-report-catalog Add blended analytic: `FastPnL_Month.csv` + `FastPnL_Ytd.csv` — DONE: added config-driven mapping (`data/fast_pnl_mapping.json`) + builder + pipeline outputs (including unclassified + recon CSVs). Commit: a086c6d.
  - “Fast P&L” = best-effort early close using GL journal lines
  - Config-driven bucket mapping: revenue/COGS/SGA/other; dept rollups
  - Include a reconciliation section: total GL activity vs sum of buckets; unclassified lines
- [x] #nextaction #project/tbh-report-catalog Add Layer 4 report pack: `Fast P&L (Draft).xlsx` — DONE: added `FastPnLDraftExcelGenerator` (EPPlus) and wired it into pipeline reports section using FastPnL analytics outputs. Commit: ff8ee9e.
  - Tabs: Summary (Month/YTD), By Dept, By Account, Unclassified, Notes/Assumptions
- [x] #nextaction #project/tbh-report-catalog Add Layer 4 report pack: `AP Spend & Pricing Check Pack.xlsx` — DONE: added `ApSpendPricingCheckPackExcelGenerator` and wired it into pipeline reports section (uses AP Spend by Vendor + AP Material Schedule analytics). Commit: 9c23f4d.
  - Tabs: Spend by vendor (Month/YTD), Materials schedule, Unit price outliers (amount/qty), Missing qty coding

#### GL-side sample data needed (provide examples so we can build the GL half of the pipeline)

- [x] #nextaction #project/tbh-report-catalog GLDT export + join-key legend — CLOSED: we are treating Command (ops/AR) vs TBH GL/AP (financial) as largely separate pipelines; GLDT mapping is not exact and cross-db joins are not a core requirement right now.
- [x] #nextaction #project/tbh-report-catalog COA slice / posted invoice journal / credit journal examples / posting rules — CLOSED: defer until we decide we explicitly need GL↔AR tie-out reports.
- [x] #nextaction #project/tbh-report-catalog Confirm invoice-level vs batch/journal-level tie-out — CLOSED for now (not in current scope).

#### TLAP/TKTX work plan (captured from chat)

**Layer 1: Extract**
- [x] #nextaction #project/tbh-report-catalog Create `TlapRecord` / `TktxRecord` model classes — DONE: added `src/Tbh.Extract/Models/CommandAlkon/TlapRecord.cs` + `TktxRecord.cs`
- [x] #nextaction #project/tbh-report-catalog Add extractor methods to the extraction interface + SQLite implementation (TLAP + TKTX) — DONE: added ExtractTlapAsync/ExtractTktxAsync to ICommandAlkonExtractor + implemented in SqliteCommandAlkonExtractor (table-exists guard). Commit: f5f742d
- [x] #nextaction #project/tbh-report-catalog Wire TLAP + TKTX into `PipelineRunner.cs` for extraction — DONE: PipelineRunner now calls ExtractTlapAsync/ExtractTktxAsync and prints extracted counts. Commit: dc40cd8

**Layer 2: Normalize**
- [x] #nextaction #project/tbh-report-catalog Add `TicketAssociatedProductAmount` to `NormalizedTicket` — DONE: added field + included in TicketDispatchTotalAmount; PipelineRunner aggregates TLAP.ext_price_amt per ticket into TicketAssociatedProductAmount. Commit: dadc9ea
- [x] #nextaction #project/tbh-report-catalog Update `TicketDispatchTotalAmount` to include TLAP — DONE: TicketDispatchTotalAmount now includes TicketAssociatedProductAmount. Commit: dadc9ea
- [x] #nextaction #project/tbh-report-catalog Aggregate TLAP by ticket key in `PipelineRunner.cs` — DONE: PipelineRunner groups TLAP (tlapNorm) by ticket key and sums ext_price_amt into TicketAssociatedProductAmount. Commit: dadc9ea
- [x] #nextaction #project/tbh-report-catalog Write normalized TLAP/TKTX CSV outputs — DONE: PipelineRunner now writes `{prefix} TicketLineAssociatedProducts.csv` (TLAP) + `{prefix} TicketTaxes.csv` (TKTX) into normalized outputs and latest, and adds artifacts to manifest. Tickets.csv also includes ticket_assoc_prod_amt. Commit: ce2efdf

**Layer 3: Analytics**
- [x] #nextaction #project/tbh-report-catalog Update docs to note TLAP inclusion (and any tax/TKTX basis assumptions) — DONE: updated docs/pipeline_inventory.md to document ticket_assoc_prod_amt + TLAP/TKTX normalized CSVs and note tax basis mismatch. Commit: c009678
- [x] #nextaction #project/tbh-report-catalog Include TLAP in `NonConcreteProductsBuilder` — DONE: NonConcreteProductsBuilder now accepts NormalizedTlap and concatenates TLAP rows into non-concrete aggregation; PipelineRunner passes `tlap`. Commit: 14175f7
- [x] #nextaction #project/tbh-report-catalog Add TLAP breakdown to reconciliation outputs — DONE: DispatchVsAR_ByInvoice + ARTB versions now include dispatch_product_amt, dispatch_charge_amt, dispatch_assoc_prod_amt columns (from ticket-level components incl TLAP). Commit: 9d9114e

**Layer 4: Reports**
- [x] #nextaction #project/tbh-report-catalog Update CFO pack to show TLAP revenue breakdown — DONE: CFO pack "Dispatch vs AR (Invoice)" sheet now includes Dispatch Product/Charges/Assoc Products (TLAP) columns; cover note updated. Commit: 5146ef0
- [x] #nextaction #project/tbh-report-catalog Update report comments/documentation for TLAP/TKTX changes — DONE: updated Dispatch→AR recon (ITRN+ARTB) cover notes to reflect TLAP included in dispatch totals; TKTX remains tax-comparison basis. Commit: 6c1b820

---

#### Previously completed
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
- [x] #nextaction #project/tbh-report-catalog Run report: Zone Performance (Month) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_173727_202501/reports/202501 Zone Performance (Month).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Zone Performance (pricing/haul implications) — DONE (dummy DB run 202501): Volume concentrated in zones WV (6,981.25 CY; 45.0% of CY; avg $155.80/CY; avg cycle 58.1m) and zone 0 (5,202.00 CY; 33.5%; avg $161.69/CY; avg cycle 73.0m). PA is 3rd (1,388.75 CY; 8.9%; $159.55/CY; 73.8m). Highest $/CY zones with meaningful volume (>=50 CY): zone 3 $202.24/CY (63 CY; 100.1m), MAR $201.99/CY (130.5 CY; 79.6m), VA3 $184.88/CY (70 CY), WV5 $182.38/CY (138.5 CY; 86.2m). Longest avg cycle times (>=20 loads): MAR 79.6m, PA 73.8m, zone 0 73.0m, PA3 71.9m. Pricing/haul implication: remote/slow zones (MAR/WV5/zone3) show higher $/CY and longer cycles—candidates for haul surcharge validation and ensuring pricing covers time cost; PA3 shows relatively low $/CY ($143.74) despite long cycle (~71.9m) → potential underpricing/inefficiency flag. Source: `runs/20260221_173727_202501/analytics/202501 ZonePerformance_Month.csv`

10) **Project Tracker (Active Projects / Large Jobs)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Project Tracker — DONE: added `ProjectTrackerExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} Project Tracker.xlsx`. Commit: 773a179
- [x] #nextaction #project/tbh-report-catalog Run report: Project Tracker — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_190731_202501/reports/202501 Project Tracker.xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Project Tracker (growth/decline, top projects) — DONE (dummy DB run 202501): 93 projects. Top by CY/rev: project 1 (ABCI01) 954.75 CY / $149,502.75 over 29 days (32.9 CY/day); project 67 (EDGE01) 628.25 CY / $91,020.75 over 14 days (44.9 CY/day); project 84 (NVRI01) 579 CY / $83,223.31 over 29 days (20.0 CY/day); project 71 (NVRI01) 539 CY / $77,409.93 over 30 days (18.0 CY/day); project 35 (SMIT01) 492.75 CY / $70,478.63. Large projects >500 CY: 4 (projects 1, 67, 84, 71). Burst jobs (>=100 CY in <=5 days): 2 (project 63: 114 CY in 1 day; project 2: 104 CY in 1 day). Note: trend/growth across months requires multi-month window; within-month signal uses days_active + avg_daily_CY. Source: `runs/20260221_190731_202501/analytics/202501 ProjectTracker.csv`

11) **Invoice Aging + Collections Dashboard**
- [x] #nextaction #project/tbh-report-catalog Implement report: Invoice Aging + Collections Dashboard — DONE: added `InvoiceAgingCollectionsDashboardExcelGenerator` (Invoice Aging + Customer Scoreboard sheets) and wired in `PipelineRunner` to emit `{prefix} Invoice Aging + Collections Dashboard.xlsx`. Commit: 102fc8d
- [x] #nextaction #project/tbh-report-catalog Run report: Invoice Aging + Collections Dashboard — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_203729_202501/reports/202501 Invoice Aging + Collections Dashboard.xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Invoice Aging + Collections Dashboard (past-due drivers) — DONE (dummy DB run 202501, as-of today): no meaningful past-due drivers surfaced because OpenBalanceAmount is 0 across customers/invoices in dummy dataset (CustomerScoreboard past_due/open all $0; InvoiceAging has no open >0). Next step for real data: rank customers by PastDueBalanceAmount and %PastDue; list top past-due invoices by open balance and days past due; provide bucket totals (1-30/31-60/61-90/90+). Source: `runs/20260221_203729_202501/analytics/202501 InvoiceAging_ByInvoice.csv` + `CustomerScoreboard_Month.csv`

12) **Credit / Adjustment Register (Month)**
- [x] #nextaction #project/tbh-report-catalog Implement report: Credit/Adjustment Register (from ITRN) — DONE: added `CreditAdjustmentRegisterExcelGenerator` and wired in `PipelineRunner` to emit `{prefix} Credit-Adjustment Register (ITRN).xlsx`. Commit: 4dcc868
- [x] #nextaction #project/tbh-report-catalog Run report: Credit/Adjustment Register (from ITRN) — DONE: ran pipeline for 2025-01-01→2025-02-01; output: `runs/20260221_220741_202501/reports/202501 Credit-Adjustment Register (ITRN).xlsx`
- [x] #nextaction #project/tbh-report-catalog Summarize report: Credit/Adjustment Register (root causes + approvals) — DONE (dummy DB run 202501): 964 rows flagged. Breakdown: 953 negative_payment (trans_type 31 with pmt_amt<0), 5 ar_adjustment_code (trans_type 41, adj code PAJ), 4 nonstandard_trans_type (trans_type 51), 2 credit_or_adjustment_amount (trans_type 43 with negative tax; totals -$248.25 and -$129.87). Biggest negative payments: ARCO02 inv 1481075 pmt -$81,844.57; MILL19 inv 1482553 -$76,983.50; ARCO02 inv 1480988 -$76,478.32; ARCO02 inv 1481206 -$65,572.18; EDGE01 inv 1482042 -$53,549.48. Root-cause interpretation: most rows are payment application lines represented as negative pmt_amt with offsetting check_amt (likely normal); true credits/adjustments are the small set of non-31 types and negative tax/amount rows. Approval focus: review nonstandard types (41/43/51), PAJ-coded adjustments, and any negative pretax/tax rows. Source: `runs/20260221_220741_202501/analytics/202501 CreditAdjustmentTracker_Transaction.csv`

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

