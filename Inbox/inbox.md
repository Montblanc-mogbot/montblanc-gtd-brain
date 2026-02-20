# Inbox

> Capture new tasks here. Keep it as a single list of checkbox items.

## Tasks
- [ ] #nextaction Weekly review (20260220) → Reference/weekly-reviews/20260220-weekly-review.md
- [x] #focus #nextaction #project/tbh-report-catalog Fix `dotnet format --verify-no-changes` whitespace error in PipelineRunner.cs (line ~311) and re-verify — DONE: ran dotnet format + verify; committed/pushed (0ad9353)
- [x] #focus #nextaction #project/tbh-report-catalog Review Report Catalog README and finalize architecture — DONE: created comprehensive README with architecture diagram, analytical datasets, reconciliation framework, and normalization rules
- [ ] #project/griddle #backlog Remember drag-bar/page split width between sessions
- [x] #focus #nextaction #project/griddle Bug: horizontal scroll snaps back (likely scroll restoration loop) — FIXED + pushed (commit cec930a)
- [ ] #project/griddle #backlog Fast entry: styling when notes are present
- [ ] #project/griddle #backlog Bug: font-only styling showing as none does not render text
- [ ] #project/griddle #backlog Hide blank row from dummy dates
- [ ] #project/griddle #backlog Settings: allow changing date format and data format overall
- [x] #focus #nextaction #project/tbh-report-catalog Create C# project skeleton with layered architecture — DONE: Full solution with 5 projects (Extract, Normalize, Analytics, Reports, ReportCatalog)
- [ ] #focus #waitingfor #project/tbh-report-catalog Matt: Sample data from slsd, plnt tables (10-20 anonymized rows)
- [x] #focus #nextaction #project/tbh-report-catalog Implement normalization layer for dispatch primary tables (TICK/TKTL/ORDR + ITRN) and export clean normalized CSVs for analytics — DONE: added ITRN extract+normalize+CSV export; dispatch CSV export already present; demo now skips missing tables gracefully
- [x] #focus #nextaction #project/tbh-report-catalog Integrate UOMS into pipeline: add normalized Uoms CSV export + update analytics to compute concrete yards via UOM filter (start with uom=40003) and add a DispatchUomSummary verification CSV — DONE: extractor+normalized export, concrete_delv_qty added, DispatchUomSummary added; commit e070fc9
- [x] #focus #nextaction #project/tbh-report-catalog Update DispatchPlantDay analytic: drop delv_qty, rename concrete_delv_qty→quantity, use ticket_count (distinct tickets), add unique_truck_count (distinct truck_code) — DONE: added truck_code to tickets; updated analytics+report; commit ed96414
- [ ] #focus #waitingfor #project/tbh-report-catalog Matt: upload `export_out.zip` (zipped export_out folder) to TBH Report Catalog Discord thread so I can ingest full exports
- [ ] #focus #waitingfor #project/tbh-report-catalog Matt: Populate Out-of-State Zone list (mapping used by OutOfStateZone analytic)
- [ ] #focus #waitingfor #project/tbh-report-catalog Matt: Provide fallback "city by zone" list (used when explicit city→zone mapping is missing)
- [ ] #focus #waitingfor #project/tbh-report-catalog Matt: GL schema (table names for expenses)
- [ ] #focus #waitingfor Collect and synthesize Griddle feedback from employee testing (waiting for employees to submit feedback)
- [x] #focus #nextaction #project/tbh-report-catalog Add ITRN CSV into SQLite dummy DB + draft CFO Dispatch/Billing report layout — DONE: imported itrn_sample.csv into data/tbh_dummy.sqlite; drafted docs/cfo-dispatch-billing-report-layout.md
- [ ] #focus #waitingfor #project/tbh-month-end-procedures Plan TBH Month End procedures project (tax workflow + process docs) — BLOCKED: need Python script overview + web search/browser access for state deadline research
- [x] #focus #nextaction Design undo/redo system for Griddle (prep for implementation) — DONE (design doc at `Projects/griddle/docs/undo-redo-design.md`)
- [ ] #waitingfor #project/moghome-discord-setup Set Montblanc bot avatar and server/channel icon (manual: requires Discord Developer Portal access)
- [ ] #waitingfor #project/linux-ricing-montblanc-fft Set Montblanc avatar (Discord/OpenClaw)
- [ ] #waitingfor #project/linux-ricing-montblanc-fft Set terminal colors in Ptyxis to match palette
- [ ] #waitingfor #project/linux-ricing-montblanc-fft Optional: tmux theme to match
- [ ] #waitingfor #project/tbh-month-end-procedures Matt: share overview of current Python scripts (structure, not credentials)
