# Griddle — Milestone 1 Plan (Pivot structure)

## Goal
Produce a working pivot view (tabular pivot like mock) driven by a schema and a dataset of records.

## Deliverables
1) **Types + contracts**
- Dataset types (`DatasetFileV1`, `DatasetSchema`, `FieldDef`, `RecordEntity`)
- Pivot types (`PivotConfig`, `PivotResult`, `PivotCell`)

2) **Pivot compute** (`computePivot(records, schema, pivotConfig) -> PivotResult`)
- build distinct `rowTuples[]` and `colTuples[]`
- build `cells` map with:
  - `value = SUM(measureKey)`
  - `recordIds[]` contributing

3) **Pivot renderer**
- left header area: one column per `rowKeys[]`
- top header area: multi-row header for `colKeys[]` (with grouping/colSpans)
- body: clickable cells

4) **Toolbar controls**
- choose `rowKeys[]` and `colKeys[]` from schema fields
- choose active `measureKey` from measure fields

5) **Selection state**
- clicking a cell stores `selectedCell = { rowTuple, colTuple, recordIds }`

## Acceptance criteria
- Given a small dataset (10–100 records), pivot renders correctly and deterministically.
- Changing the active measure updates cell values.
- Multi-row column headers and multi-col row headers render in the requested style.
- Clicking a cell exposes implied dimension values + recordIds (visible in a debug panel is fine for v1).

## Out of scope
- Record creation/editing UI
- Date bucketing
- Avg/min/max/count selection
- Persistence beyond JSON import/export (optional in M1)
