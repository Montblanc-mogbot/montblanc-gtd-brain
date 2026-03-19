# Month-end checklist template (Monthly Reconciliation)

Use this file as the reusable monthly close template. Copy it into a period folder (recommended) and check items off as you go.

Suggested foldering:
- `Projects/monthly-reconciliation/runs/YYYY-MM/`
  - `checklist.md` (copy of this template)
  - `inputs/` (exports)
  - `outputs/` (final PDFs, receipts)
  - `notes.md` (what went weird, what to improve)

---

## Header
- Period: `YYYY-MM`
- Prepared by:
- Started at:
- Finished at:
- Systems/portals involved:

## Guardrails (sensitive data)
- [ ] No credentials, account numbers, EINs, SSNs, or bank info are stored in this vault.
- [ ] Any exported files saved here are verified to be safe/sanitized.
- [ ] If a file contains sensitive info, it stays outside the vault and is referenced only by description.

## 1) Inputs (what you need before running)
### Source exports (attach paths / filenames)
- [ ] Command Alkon export(s):
  - Path(s):
- [ ] AR/GL exports / control totals:
  - Path(s):
- [ ] Prior month carryovers/credits (if any):
  - Notes:

### Period definition
- [ ] Period start date (YYYY-MM-01):
- [ ] Period end date (YYYY-(MM+1)-01):
- [ ] Cutoff policy documented (invoice date vs transaction date):

## 2) Prep & snapshot
- [ ] Create period folder: `runs/YYYY-MM/`
- [ ] Save input exports into `runs/YYYY-MM/inputs/`
- [ ] Record versions/assumptions (software versions, report filters used)

## 3) Run calculations
(Manual steps and/or scripts; keep this high-level and credential-free.)

- [ ] Run calculation step(s) to produce state worksheets
- [ ] Produce consolidated summary (all states)
- [ ] Save intermediate outputs to `runs/YYYY-MM/outputs/` (sanitized)

## 4) Reconcile (control checks)
### Tie-outs
- [ ] Totals tie to AR/GL control total(s)
  - Control report name:
  - Expected total:
  - Observed total:
  - Delta + explanation:

### Variance analysis
- [ ] Compare to prior period (flag material variances)
  - Notes:

### Spot checks
- [ ] Spot-check high-dollar / unusual items
  - Notes:

## 5) Filing / submission (per state)
Create one block per state you file.

### State: ____
- [ ] Taxable base computed
- [ ] Tax due computed
- [ ] Portal submission completed
- [ ] Payment scheduled/sent
- [ ] Receipt / confirmation captured (sanitized)
  - Receipt location:
- [ ] Notes / exceptions:

(Repeat for MD / WV / PA / VA, as applicable.)

## 6) Archive & close
- [ ] Save final receipts/PDFs to `runs/YYYY-MM/outputs/` (sanitized)
- [ ] Write a short post-mortem in `runs/YYYY-MM/notes.md`
  - What changed vs last month
  - What was annoying / error-prone
  - What to automate next
- [ ] Update project hub with any improvements to the template

## 7) Follow-ups / improvements
- [ ] Capture 1–3 improvement ideas for next month
- [ ] If something broke, open an issue/todo for it
