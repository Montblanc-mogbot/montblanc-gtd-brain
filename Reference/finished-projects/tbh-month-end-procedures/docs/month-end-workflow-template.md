# TBH Month-End Workflow — Template (Sanitized)

Purpose: a state-agnostic, credential-free template we can fill in once we have the (redacted) Python script structure and state portal specifics.

## 0) Guardrails (sensitive data boundary)

Never include in this repo/docs:
- Account numbers, bank routing, login credentials
- EINs, employee SSNs, payroll identifiers
- Any portal usernames/passwords or API keys

Safe to include:
- Process steps, checklists, deadlines, and decision trees
- Query shapes / report names (without credentials)
- File/folder structure (script names, modules) with secrets omitted

## 1) Monthly timeline

- T-3 business days: data readiness checks
- T-1 business day: draft calculations + reconcile
- Filing day(s): submit payments/returns
- T+1 business day: archive proof + post-mortem notes

## 2) Inputs

### 2.1 Data sources
- Command Alkon exports (dispatch/billing)
- AR/GL exports (for cross-checks)
- Prior period carryover (credits, adjustments)

### 2.2 Period definition
- Period start: YYYY-MM-01
- Period end: YYYY-(MM+1)-01
- Cutoff policy: (define) invoice date vs transaction date

## 3) Outputs

For each state (MD/WV/PA/VA), we want:
- Amounts computed (taxable base, tax due, penalties/interest if any)
- Payment confirmation / submission receipt
- Saved PDF(s) or export(s) from portals
- Internal reconciliation worksheet (what changed vs last month)

## 4) Standard workflow (repeatable)

### Step A — Prep & snapshot
- [ ] Create period folder (e.g., `YYYY-MM/`)
- [ ] Snapshot key source reports (exports saved to period folder)
- [ ] Confirm prior-month open items / credits (if applicable)

### Step B — Run calculations (scripts)
- [ ] Run month-end script(s) in read-only mode
- [ ] Produce state worksheets (one per state)
- [ ] Produce a consolidated summary sheet

### Step C — Reconcile
Minimum checks (generic):
- [ ] Totals tie out to AR/GL control totals (define control reports)
- [ ] Compare to prior period (variance flags)
- [ ] Spot-check a few high-dollar transactions

### Step D — Submit
Per state:
- [ ] Log in to portal (manual)
- [ ] Enter/Upload numbers
- [ ] Submit return
- [ ] Submit payment (ACH/other)
- [ ] Save confirmation (PDF/screenshot)

### Step E — Archive & notes
- [ ] Store confirmations in period folder
- [ ] Record any exceptions (late data, adjustments, portal issues)
- [ ] Add “what to fix next month” notes

## 5) State-specific sections (to be filled)

### Maryland (MD)
- Portal:
- Filing frequency:
- Required fields:
- Payment method:
- Special rules:

### West Virginia (WV)
- Portal:
- Filing frequency:
- Required fields:
- Payment method:
- Special rules:

### Pennsylvania (PA)
- Portal:
- Filing frequency:
- Required fields:
- Payment method:
- Special rules:

### Virginia (VA)
- Portal:
- Filing frequency:
- Required fields:
- Payment method:
- Special rules:

## 6) Automation opportunities (safe)

- A “sanitized runner” that:
  - reads exported CSVs
  - computes totals
  - produces printable worksheets
  - never stores credentials

- Add preflight checks:
  - missing exports
  - period mismatch
  - outlier detection

## 7) Open questions (for Matt)

1) What are the script entrypoints and outputs (filenames), redacted?
2) What’s the exact cutoff rule (invoice date vs transaction date vs batch date)?
3) Which control totals do you trust (GLDT? ITRN/ARTB? portal history)?
4) Any recurring gotchas per state?
