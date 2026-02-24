# Project: TBH Month End Procedures

- **Created:** 2026-02-13
- **Status:** Active
- **Outcome (what done looks like):**
  - Documented month-end tax workflow (sales/use tax + withholding) for MD, WV, PA, VA
  - Clear, repeatable process that's easier to run each month
  - Potential for automation improvements (where sensitive data allows)
  - Handoff-ready documentation for future Matt or assistant

## Context
- Current process uses database access via Python
- Sensitive financial data involved — need to design around data privacy
- States: Maryland (MD), West Virginia (WV), Pennsylvania (PA), Virginia (VA)
- Activities: sales tax, use tax, withholding payments

## TODO

### NEXT ACTION
- [x] #nextaction #project/tbh-month-end-procedures Draft generic month-end workflow template (sanitized, state-agnostic) — DONE: `Projects/tbh-month-end-procedures/docs/month-end-workflow-template.md`
- [ ] #nextaction #project/tbh-month-end-procedures Identify which parts of process have sensitive data vs. can be generalized
- [ ] #nextaction #project/tbh-month-end-procedures Create sanitized process diagram (no real account numbers/credentials)
- [ ] #nextaction #project/tbh-month-end-procedures Research state-specific filing requirements and deadlines
- [ ] #nextaction #project/tbh-month-end-procedures Design redacted/abstracted version Montblanc can help with

### WAITING
- [ ] #waitingfor #project/tbh-month-end-procedures Matt: share overview of current Python scripts (structure, not credentials) — BLOCKS: documenting current workflow
- [ ] #waitingfor #project/tbh-month-end-procedures Matt: confirm which parts are OK to document vs. keep offline

### DONE

## Someday / Maybe
- [ ] #someday #project/tbh-month-end-procedures Automate data pulls (if API access available)
- [ ] #someday #project/tbh-month-end-procedures Build validation checks before submission
- [ ] #someday #project/tbh-month-end-procedures Calendar integration for filing deadlines

## Notes / Context
- Sensitive data: account numbers, EINs, bank details, employee SSNs/payroll data
- Non-sensitive: process steps, state requirements, calculation logic, deadline schedules
- Goal: make Matt's life easier without compromising security
