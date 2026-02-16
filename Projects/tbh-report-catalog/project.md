# Project: TBH Report Catalog

- **Created:** 2026-02-16
- **Status:** Active
- **Outcome (what done looks like):**
  - Normalized reporting architecture spanning Dispatch and Accounting systems
  - Layered data pipeline (Extract → Normalize → Analyze → Report)
  - Clear distinction between operational and financial truth
  - CFO-ready executive reports + drillable operations reports
  - Handoff-ready documentation for stepping into CFO role

## Context
- Current treasurer isn't focused on reporting/analytics
- Matt stepping into CFO role needs clear, trustworthy data
- Two systems of record (Dispatch DB + Accounting DB) that don't always agree
- Need both operational reality (Dispatch) and financial recognition (Accounting)
- Excel as primary interface (accessible, flexible)

## Next Actions
- [ ] #nextaction #project/tbh-report-catalog Review Report Catalog README and finalize architecture (see feedback below)
- [ ] #nextaction #project/tbh-report-catalog Inventory existing Python scripts for extraction layer
- [ ] #nextaction #project/tbh-report-catalog Document current normalization rules (plant codes, material names, etc.)
- [ ] #nextaction #project/tbh-report-catalog Build prototype Plant Performance analytical dataset
- [ ] #nextaction #project/tbh-report-catalog Design Executive Summary report template

## Waiting On
- [ ] #waitingfor #project/tbh-report-catalog Matt: confirm prioritization of analytical datasets (which reports are needed first?)
- [ ] #waitingfor #project/tbh-report-catalog Matt: identify existing Excel reports to migrate/catalog

## Someday / Maybe
- [ ] #someday #project/tbh-report-catalog Automate extraction pipeline (scheduled monthly pulls)
- [ ] #someday #project/tbh-report-catalog Build data quality / reconciliation alerts
- [ ] #someday #project/tbh-report-catalog Griddle integration for interactive operations reports
- [ ] #someday #project/tbh-report-catalog PowerBI or similar for executive dashboards

## Notes / Context
- Each analytical dataset answers ONE business question well
- Normalized data must be explainable to an auditor in plain English
- Reconciliation layer bridges operational vs. financial truth — don't force them to agree prematurely
