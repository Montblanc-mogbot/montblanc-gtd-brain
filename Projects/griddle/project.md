# Project: Griddle (schema-driven pivot + data entry)

- **Created:** 2026-02-06
- **Status:** Active
- **Outcome (what done looks like):**
  - Users can load/save a dataset (JSON) with a schema describing field roles
  - Pivot view renders: multi-row column headers + multi-col row headers (like the mock)
  - User can select active **Measure** (dropdown) and see SUM values in cells
  - Cell selection provides implied dimension values + contributing record ids (hooks for later entry/forms)

## Next Actions (TODOs)
- [x] #nextaction #project/griddle Create initial design docs folder + core documents (overview, data model, pivot spec, milestone plan)
- [x] #nextaction #project/griddle Define v1 data model types (DatasetFileV1, FieldDef, RecordEntity, PivotConfig)
- [x] #nextaction #project/griddle Specify Pivot compute output contract (row tuples, col tuples, cell map w/ recordIds)
- [x] #nextaction #project/griddle Write Milestone 1 implementation plan + acceptance criteria (pivot only)

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
