# Data Pipeline

## TL;DR
A data ingestion/transform pipeline (define sources, transforms, validation, outputs) with repeatable runs and clear observability.

## Repo(s)
- (unknown yet) If there is a repo under `/home/montblanc/repos/`, link it here.

## Discord thread
- Thread/channel link/id: channel:1472975197031366779  ("TBH Report Catalog")

## Pulse tracking (anti-spam)
- last_pulse_at: 2026-03-18T10:08
- last_pulse_message_id: 1483829448192168054
- awaiting_matt: true

## Context / where notes live
- Project hub (this file)
- How to run locally: `Projects/data-pipeline/how-to-run-locally.md`
- Any technical notes: `Reference/tech-notes/` (if applicable)

## Goals
- Reliable, repeatable pipeline runs
- Validation + clear failure modes
- Outputs consumable by downstream reporting/workflows

## What done looks like (definition of done)
- One-command run (or scheduled) that produces expected outputs
- Automated checks/validation
- Minimal documentation: how to run, how to add a source/transform

## Current status
- Not yet captured.

## Next actions
- [x] #nextaction Write/refresh “How to run the pipeline locally” (inputs, env vars, commands, expected outputs). — DONE: wrote Projects/data-pipeline/how-to-run-locally.md
- [x] #nextaction Add an end-to-end smoke test (small fixture → expected reconciliation outputs). — DONE: added xUnit test project `src/Tbh.ReportCatalog.Tests` with fixture packaging + smoke test; `dotnet test -c Release` passes
- [ ] #nextaction #waitingfor Confirm target schedule (manual vs cron) + where outputs land (files/db/reporting). — ASKED Matt in channel:1472975197031366779 (msg 1483857559772336360)

