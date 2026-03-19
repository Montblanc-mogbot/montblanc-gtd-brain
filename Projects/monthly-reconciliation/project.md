# Monthly Reconciliation Workflow

## TL;DR
A repeatable monthly close / reconciliation workflow with clear steps, checklists, automation opportunities, and audit-friendly documentation.

## Repo(s)
- (notes-only by default) If there’s automation code, link repo here.

## Discord thread
- Thread/channel link/id: channel:1483489940942884934  ("202601 Material Schedule")

## Pulse tracking (anti-spam)
- last_pulse_at: 2026-03-18T10:08
- last_pulse_message_id: 1483829451228713062
- awaiting_matt: true

## Context / where notes live
- Project hub (this file)
- Procedures/docs location (canonical for now): `Reference/finished-projects/tbh-month-end-procedures/docs/month-end-workflow-template.md`

## Goals
- Reduce time + errors in month-end
- Make it easy to resume mid-stream
- Keep sensitive data handling explicit

## What done looks like (definition of done)
- Written procedure/checklist that can be followed start-to-finish
- Defined inputs/outputs per step
- Optional automation scripts documented (how to run, what they touch)

## Current status
- Captured: checklist template + canonical procedure template.
- Next: pick 1 automation candidate that is safe (no credentials/sensitive data in-vault).

## Next actions
- [x] #nextaction Capture canonical procedure doc location (vault path/file) and link it here. — DONE: `Reference/finished-projects/tbh-month-end-procedures/docs/month-end-workflow-template.md`
- [x] #nextaction Create a month-end checklist template (inputs → steps → outputs) and reuse it monthly. — DONE: `Projects/monthly-reconciliation/month-end-checklist-template.md`
- [x] #nextaction Identify 1 automation candidate (script/report pull) and define safe inputs/outputs + where code lives. — DONE (candidate chosen; see “Automation candidate” section below)

## Automation candidate (safe)

### Candidate
**“Sanitized export runner”**: a small wrapper around the existing `tbh_single_table_exporter.py` to standardize month-end *read-only* exports.

Why this one:
- It’s a clear, bounded automation win: repeatable data pull shape.
- Can be designed to be **credential-safe** (no engine URL in-vault; use env var or local-only config file outside vault).
- Produces explicit inputs/outputs that are audit-friendly.

### Where code lives
- Current script: `tbh_single_table_exporter.py` (workspace root)
- If we formalize it, suggest moving into:
  - `Projects/monthly-reconciliation/automation/` (notes-first) OR a dedicated repo under `/home/montblanc/repos/` if it grows.

### Inputs (safe contract)
- Period: `YYYY-MM`
- Target table name (e.g., `TLAP`, `TLAC`, etc.)
- Mode:
  - by tick codes: `TICK.csv` path + column mapping
  - or by date: date column + start/end
- Connection string **NOT stored in vault**:
  - `TBH_DB_URL` environment variable OR
  - a local-only file outside this workspace (document path, don’t commit contents)

### Outputs
- One CSV per run written to a predictable folder, e.g.:
  - `Projects/monthly-reconciliation/runs/YYYY-MM/inputs/db_exports/<table>.csv`
- A small `run.json` metadata file (safe) capturing:
  - timestamp
  - period
  - script version (git commit hash if in repo)
  - table name
  - row count
  - filters used (tick-code count, date bounds)

### Guardrails
- Must run in read-only mode (SELECT-only).
- Never print connection strings to logs.
- Validate output filenames/paths (avoid overwriting unintended files).
- If exports contain sensitive fields, store them outside vault and only reference them.

