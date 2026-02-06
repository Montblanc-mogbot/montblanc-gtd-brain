# Project: Griddle (schema-driven pivot + data entry)

- **Created:** 2026-02-06
- **Status:** Active
- **Outcome (what done looks like):**
  - Users can load/save a dataset (JSON) with a schema describing field roles
  - Pivot view renders: multi-row column headers + multi-col row headers (like the mock)
  - User can select active **Measure** (dropdown) and see SUM values in cells
  - Cell selection provides implied dimension values + contributing record ids (hooks for later entry/forms)

## Next Actions (TODOs)
### Setup
- [x] #nextaction #project/griddle Decide repo name + visibility (public/private)
- [x] #nextaction #project/griddle Create GitHub repo (gh) + initialize local repo
- [x] #nextaction #project/griddle Scaffold app (Vite + React + TS) + lint/format

### Milestone 1 — Pivot structure
- [x] #nextaction #project/griddle Implement domain types (dataset/schema/records) (in repo: src/domain/types.ts)
- [x] #nextaction #project/griddle Implement pivot compute (tuples + cell map + SUM) (in repo: src/domain/pivot.ts)
- [x] #nextaction #project/griddle Implement pivot grid renderer (multi-header rows/cols) (in repo: src/components/PivotGrid.tsx)
- [x] #nextaction #project/griddle Implement measure selector + row/col selectors (in repo: src/components/PivotControls.tsx)
- [x] #nextaction #project/griddle Implement cell selection state + debug panel (in repo: src/App.tsx)

### Quality
- [x] #nextaction #project/griddle Add basic sample dataset + snapshot-ish test (unit tests via vitest: src/domain/pivot.test.ts)
- [x] #nextaction #project/griddle Write README with run instructions + current limitations (in griddle repo README.md)

### Next chunk (still Milestone 1 / polish)
- [ ] #nextaction #project/griddle Add import/export of dataset JSON (local file) so Matt can test with real data
- [ ] #nextaction #project/griddle Improve header rendering correctness (grouping/colSpan edge cases) + add sticky top row headers
- [ ] #nextaction #project/griddle Add basic slicers UI (optional; compute supports it)

(Completed)
- [x] #project/griddle Create initial design docs folder + core documents (overview, data model, pivot spec, milestone plan)
- [x] #project/griddle Define v1 data model types (DatasetFileV1, FieldDef, RecordEntity, PivotConfig)
- [x] #project/griddle Specify Pivot compute output contract (row tuples, col tuples, cell map w/ recordIds)
- [x] #project/griddle Write Milestone 1 implementation plan + acceptance criteria (pivot only)

## Design Docs
- `docs/00-overview.md`
- `docs/01-data-model.md`
- `docs/02-pivot-spec.md`
- `docs/03-milestone-1-plan.md`

## Waiting On
- [ ] #waitingfor #project/griddle Any additional example records / sample dataset (optional)

## Notes / Context
- Source thread: Discord #Structured JSON Editor (Griddle direction)
- Terminology (proposed): Dimensions (rows/cols), Slicers (true filters), Measures, Flags
