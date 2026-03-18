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
- [ ] #nextaction Write/refresh “How to run the pipeline locally” (inputs, env vars, commands, expected outputs).
- [ ] #nextaction Add an end-to-end smoke test (small fixture → expected reconciliation outputs).
- [ ] #nextaction Confirm target schedule (manual vs cron) + where outputs land (files/db/reporting).

