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

### Milestone 2 — Usable pivot demo (dummy data + selection inspector)
- [x] #nextaction #project/griddle Replace selection debug with a proper "Selection Inspector" panel/drawer
- [x] #nextaction #project/griddle Show selected cell coordinates (row+col dimension values) + aggregated value
- [x] #nextaction #project/griddle List contributing records for the selected cell (at least IDs; preferably small table)
- [x] #nextaction #project/griddle Improve pivot table visuals (sticky headers, hover, selected cell state)
- [x] #nextaction #project/griddle Push commit(s) + README note that Milestone 2 is done and how to test selection

### Milestone 3 — Schema editor (move fields/roles without code)
- [x] #nextaction #project/griddle Move dataset into React state (stop using a const) + update pivot to use state
- [x] #nextaction #project/griddle Add Schema Editor panel/page: list fields + select field to edit
- [x] #nextaction #project/griddle Implement field CRUD: add, edit (key/label/type), delete
- [x] #nextaction #project/griddle Implement role editing (rowDim/colDim/slicer/measure/flag) with validation (at least one role optional)
- [x] #nextaction #project/griddle Update PivotControls options to reflect schema changes live
- [x] #nextaction #project/griddle Add minimal "enum" editor for categorical fields (optional, but useful)
- [x] #nextaction #project/griddle README update: how to use Schema Editor
- [x] #nextaction #project/griddle Push commits and mark Milestone 3 complete

### Milestone 3.1 — Correctness + maintainable styling
- [x] #nextaction #project/griddle Implement field key rename migration (schema change should move record.data keys + pivotConfig keys)
- [x] #nextaction #project/griddle Add tests for schema migration helper (rename + delete behavior)
- [x] #nextaction #project/griddle PivotControls: drive eligible fields by roles (not by FieldType)
- [x] #nextaction #project/griddle Styling refactor: reduce inline styles (start with PivotGrid + inspectors) and introduce a consistent CSS approach (e.g., CSS modules)
- [x] #nextaction #project/griddle UI polish direction: add a short note on recommended UI library candidates (Mantine/Chakra/MUI) and why
- [x] #nextaction #project/griddle Push commits + mark Milestone 3.1 complete

### Milestone 4 — Dataset JSON format docs + import/export
**Goal:** Document the JSON format and let users import/export datasets.

#### A) JSON format documentation
- [x] #nextaction #project/griddle Create `docs/dataset-json-format.md` describing `DatasetFileV1` (schema + records) + versioning rules
- [x] #nextaction #project/griddle Add example dataset JSON snippet(s) to the doc (minimal + slightly richer)

#### B) Domain: parse/validate/serialize
- [x] #nextaction #project/griddle Create module `src/domain/datasetIo.ts`
- [x] #nextaction #project/griddle Add function `serializeDataset(dataset: DatasetFileV1): string`
- [x] #nextaction #project/griddle Add function `parseDatasetJson(text: string): DatasetFileV1`
- [x] #nextaction #project/griddle Add function `validateDataset(dataset: DatasetFileV1): string[]` (warnings)
- [x] #nextaction #project/griddle Add function `ensureDatasetV1(input: unknown): DatasetFileV1` (throws user-facing error)

#### C) UI: Import/Export component
- [x] #nextaction #project/griddle Create component `src/components/DatasetImportExport.tsx`
- [x] #nextaction #project/griddle Add helper `downloadTextFile(filename: string, content: string)`
- [x] #nextaction #project/griddle Add handler `handleExport()` (uses `serializeDataset`)
- [x] #nextaction #project/griddle Add handler `handleImportFile(file: File)` (reads file text + `parseDatasetJson`)
- [x] #nextaction #project/griddle Add UI: Import button + hidden file input + Export button + error display

#### D) App wiring
- [x] #nextaction #project/griddle Add method `applyImportedDataset(next: DatasetFileV1)` in `App.tsx` (setDataset + reconcile PivotConfig)
- [x] #nextaction #project/griddle Add helper `reconcilePivotConfig(schema: DatasetSchema, prev: PivotConfig): PivotConfig` (keeps keys valid, picks default measure)
- [x] #nextaction #project/griddle Integrate `DatasetImportExport` into the main toolbar

#### E) Tests
- [x] #nextaction #project/griddle Create `src/domain/datasetIo.test.ts`
- [x] #nextaction #project/griddle Test: parse/serialize round-trip stable for a sample dataset
- [x] #nextaction #project/griddle Test: invalid JSON / invalid version produces a friendly error

#### F) Finish
- [x] #nextaction #project/griddle Update repo README: how to import/export
- [x] #nextaction #project/griddle Push commits and mark Milestone 4 complete

**Acceptance criteria:**
- You can export the current dataset to a JSON file
- You can import a dataset JSON file and see schema + pivot update immediately
- Invalid files fail gracefully (no crash) with actionable error text
- JSON format is documented in-repo with examples

### Milestone 5 — Record tape + fast entry (measures+metadata only)
**Goal:** Selecting a pivot cell opens an entry panel with: implied dims header + tape of contributing records + fast entry for measures/flags.

#### A) Domain: selection + record filtering
- [x] #nextaction #project/griddle Add type `CellSelectionContext` (row tuple, col tuple, recordIds, implied dims)
- [x] #nextaction #project/griddle Add function `getRecordsForCell(dataset: DatasetFileV1, selected: SelectedCell): RecordEntity[]`
- [x] #nextaction #project/griddle Add function `createRecordFromSelection(args)` (implied dims + entered measures + metadata) → `RecordEntity`
- [x] #nextaction #project/griddle Add function `updateRecordMetadata(record: RecordEntity, flagKey: string, value: boolean): RecordEntity`
- [x] #nextaction #project/griddle Add function `bulkSetMetadata(records: RecordEntity[], flagKey: string, value: boolean): RecordEntity[]`
- [x] #nextaction #project/griddle Add helper `upsertRecords(dataset: DatasetFileV1, updated: RecordEntity[]): DatasetFileV1`

#### B) UI: Entry panel shell + header
- [x] #nextaction #project/griddle Create component `EntryPanel.tsx`
- [x] #nextaction #project/griddle Create component `EntryHeader.tsx` (lists implied row/col/slicer dims + shows aggregate + record count)

#### C) UI: Tape list (records in cell)
- [x] #nextaction #project/griddle Create component `RecordTape.tsx` (renders contributing records)
- [x] #nextaction #project/griddle Create component `RecordTapeRow.tsx` (shows measure values + metadata checkboxes; metadata editable per row)
- [x] #nextaction #project/griddle Implement “tape updates live” (re-renders after insert/update)

#### D) UI: Fast entry form (tape-calculator behavior)
- [x] #nextaction #project/griddle Create component `FastEntryForm.tsx`
- [x] #nextaction #project/griddle Implement `measureFieldKeys` selector (schema fields with role=measure; stable ordering)
- [x] #nextaction #project/griddle Implement `flagFieldKeys` selector (schema fields with role=flag; stable ordering)
- [x] #nextaction #project/griddle Implement keyboard flow (Enter advance; Enter submit last; after submit clear + focus first)
- [x] #nextaction #project/griddle Implement metadata checkboxes for the record being entered (default false)

#### E) UI: Bulk metadata edit for cell
- [x] #nextaction #project/griddle Create component `BulkMetadataEdit.tsx` (simple checkbox per flag)
- [x] #nextaction #project/griddle Implement handler `onBulkFlagToggle(flagKey, checked)` sets all records in cell to checked

#### F) App wiring
- [x] #nextaction #project/griddle Add state `selectedCell` → opens EntryPanel when non-null
- [x] #nextaction #project/griddle Implement `handleSubmitEntry()` in App: append new record + recompute pivot
- [x] #nextaction #project/griddle Implement `handleToggleRowFlag(recordId, flagKey, value)` in App: update dataset record + recompute pivot
- [x] #nextaction #project/griddle Implement `handleBulkToggle(flagKey, value)` in App
- [x] #nextaction #project/griddle Ensure EntryPanel operates strictly on roles (dims implied; only measures/flags editable)

#### G) Tests (light but important)
- [x] #nextaction #project/griddle Add unit tests for `createRecordFromSelection`
- [x] #nextaction #project/griddle Add unit tests for `bulkSetMetadata` + `upsertRecords`

#### H) Finish
- [x] #nextaction #project/griddle Update README with “fast entry” workflow + keyboard rules
- [x] #nextaction #project/griddle Push commits and mark Milestone 5 complete

### Milestone 5.1 — Entry panel tape layout + styling + formatting
**Goal:** Make the Entry panel match the approved “tape calculator” ledger mockup; remove inline styles; fix white-on-white; format numbers sanely.

#### A) Styling refactor (CSS modules)
- [x] #nextaction #project/griddle Create `entryPanel.module.css` and move EntryPanel/EntryHeader/BulkMetadata styles out of inline
- [x] #nextaction #project/griddle Create `tapeLedger.module.css` and move tape row/table styles out of inline
- [x] #nextaction #project/griddle Ensure all text is readable (no white-on-white) for tape and selection panels

#### B) Number formatting
- [x] #nextaction #project/griddle Add helper `formatNumber(value: number, opts?)` (default 2 decimals) and use for cell totals + tape measures
- [x] #nextaction #project/griddle Ensure pivot cell display and EntryHeader total use the same sane formatting

#### C) Tape ledger layout (table-like)
- [x] #nextaction #project/griddle Replace RecordTape list with a table-like ledger: sticky column headers, one row per record (measures + flags inline)
- [x] #nextaction #project/griddle Move Bulk metadata section above the tape (as approved)
- [x] #nextaction #project/griddle Replace FastEntryForm with a shaded bottom “new entry” row aligned to columns
- [x] #nextaction #project/griddle Keyboard rules: Enter advances measures; Enter on last submits; clears row and focuses first input

#### D) Finish
- [x] #nextaction #project/griddle README update: tape layout + formatting notes
- [x] #nextaction #project/griddle Push commits, merge to master, and mark Milestone 5.1 complete

### Milestone 6a — AG Grid Community spike (multi-cell selection)
**Goal:** Prototype the pivot grid rendered with AG Grid Community and confirm multi-cell/range selection behavior.

- [x] #nextaction #project/griddle Decide target AG Grid version + install deps (`ag-grid-community`, `ag-grid-react`) and theme CSS
- [x] #nextaction #project/griddle Create `src/spikes/AgGridPivotSpike.tsx` (renders pivot via AG Grid)
- [x] #nextaction #project/griddle Create pivot→AGGrid adapter: `makeAgGridTable(pivot, config)` returning `columnDefs` + `rowData`
- [x] #nextaction #project/griddle Enable range selection + multi-range (if supported) and add event logging (`onRangeSelectionChanged`)
- [x] #nextaction #project/griddle Add simple UI toggle in App: switch between current table and AG Grid spike
- [x] #nextaction #project/griddle Document findings in `docs/ag-grid-spike.md` (does multi-cell selection work in Community? any caveats)
- [x] #nextaction #project/griddle Push commits + mark Milestone 6a complete

### Milestone 6b — Multi-cell selection OSS spikes (Glide Data Grid + ReactGrid)
**Goal:** Evaluate free/OSS grids for spreadsheet-like multi-cell selection for the pivot view.

#### Glide Data Grid spike
- [x] #nextaction #project/griddle Install deps for Glide Data Grid and add minimal CSS
- [x] #nextaction #project/griddle Create `src/spikes/GlidePivotSpike.tsx` and pivot→Glide adapter
- [x] #nextaction #project/griddle Confirm range selection + multi-selection behavior; add event logging

#### ReactGrid spike
- [x] #nextaction #project/griddle Install deps for ReactGrid and add required styles
- [x] #nextaction #project/griddle Create `src/spikes/ReactGridPivotSpike.tsx` and pivot→ReactGrid adapter
- [x] #nextaction #project/griddle Confirm range selection + multi-selection behavior; add event logging

#### App wiring + docs
- [x] #nextaction #project/griddle Add App toggle(s) to switch between: current grid / AG Grid spike / Glide spike / ReactGrid spike
- [x] #nextaction #project/griddle Document findings in `docs/multicell-grid-spike.md` (selection UX, keyboard, performance notes, licensing)
- [x] #nextaction #project/griddle Push commits + mark Milestone 6b complete

### Milestone 6c — Multi-cell selection comparison (Glide vs MUI DataGrid)
**Goal:** Compare selection UX in Glide Data Grid vs MUI X DataGrid (community) under our current stack.

#### Glide spike (fix + surface selection)
- [x] #nextaction #project/griddle Fix Glide build issues (install missing deps like lodash; remove legacy-peer hacks if possible)
- [x] #nextaction #project/griddle Add App spike view option for Glide and verify drag range selection + multi-select behavior

#### MUI DataGrid spike
- [x] #nextaction #project/griddle Install MUI deps (`@mui/material`, `@emotion/react`, `@emotion/styled`, `@mui/x-data-grid`)
- [x] #nextaction #project/griddle Create `src/spikes/MuiDataGridPivotSpike.tsx` and pivot→rows/columns adapter
- [x] #nextaction #project/griddle Verify what selection modes exist in community (cell focus, row selection, checkbox selection) and document limitations

#### App wiring + docs
- [x] #nextaction #project/griddle Update App spike selector to include: Glide, MUI DataGrid (keep AG Grid for reference)
- [x] #nextaction #project/griddle Document findings in `docs/multicell-grid-spike.md` (Glide vs MUI; selection, keyboard, licensing)
- [x] #nextaction #project/griddle Push commits + mark Milestone 6c complete

### Milestone 7 — Glide main grid + multi-level headers + selection→Entry drawer
**Goal:** Replace the main pivot grid with Glide Data Grid, add a custom multi-row column header overlay (Option A), and wire single-cell selection to open the Entry side panel.

#### A) Replace main grid with Glide
- [x] #nextaction #project/griddle Make Glide a first-class view (not a spike) and use it for the main pivot grid
- [x] #nextaction #project/griddle Remove/disable old PivotGrid from default UI path (keep behind a dev toggle if desired)

#### B) Multi-level column header overlay (Option A)
- [x] #nextaction #project/griddle Create `src/components/GlidePivotHeader.tsx` (renders one header row per col dimension with grouping/spans)
- [x] #nextaction #project/griddle Create `src/domain/pivotHeaders.ts` helper to compute grouped header rows (labels + span widths)
- [x] #nextaction #project/griddle Implement horizontal scroll sync between header overlay and DataEditor (`onVisibleRegionChanged` tx)

#### C) Selection wiring to Entry panel
- [x] #nextaction #project/griddle Create `src/components/GlidePivotGrid.tsx` wrapper around DataEditor for pivot rendering
- [x] #nextaction #project/griddle Implement mapping: Glide selected cell → our `SelectedCell` (rowTuple/colTuple/value/recordIds)
- [x] #nextaction #project/griddle On single-cell selection in value area, open EntryPanel; on range selection, do not open (yet)

#### D) Finish
- [x] #nextaction #project/griddle Update README with new default grid engine (Glide) + selection behavior
- [x] #nextaction #project/griddle Push/merge + mark Milestone 7 complete

### Milestone 8 — Filters + Views System
**Goal:** Replace the old slicers approach with a unified filters system + saved views. Filters are set per-dimension in one place; views are saved filter configurations.

**Concepts:**
- **Filter:** A dimension + selected values (include/exclude/multiselect). All filters live in one "Filter Set."
- **View:** A named, saved Filter Set that can be recalled from the hotbar.

#### A) Domain: Filter types and state
- [x] #nextaction #project/griddle Add types: `DimensionFilter { dimensionKey: string; mode: 'include'|'exclude'; values: string[] }`
- [x] #nextaction #project/griddle Add type: `FilterSet { name?: string; filters: DimensionFilter[] }`
- [x] #nextaction #project/griddle Add type: `View { id: string; name: string; filterSet: FilterSet; createdAt: string }`
- [x] #nextaction #project/griddle Add filter application to pivot compute (filter records before aggregation)

#### B) UI: Filter Popup (Excel-style)
- [x] #nextaction #project/griddle Create component `FilterPopup.tsx` (modal/drawer)
- [x] #nextaction #project/griddle Show list of dimensions; clicking a dimension opens its filter UI
- [x] #nextaction #project/griddle Per-dimension filter UI: list all unique values with checkboxes; select-all/none; include/exclude toggle
- [x] #nextaction #project/griddle Search within dimension values (for long lists)
- [x] #nextaction #project/griddle Apply button: updates active FilterSet and recomputes pivot
- [x] #nextaction #project/griddle Cancel button: discards changes

#### C) UI: Filter Button in Hotbar
- [x] #nextaction #project/griddle Add "Filters" button to main toolbar/hotbar
- [x] #nextaction #project/griddle Show badge with active filter count (e.g., "Filters (3)")
- [x] #nextaction #project/griddle Click opens Filter Popup

#### D) UI: Views Section in Hotbar
- [x] #nextaction #project/griddle Create `ViewsDropdown.tsx` in hotbar
- [x] #nextaction #project/griddle Show saved views list; click to load (replace current FilterSet)
- [x] #nextaction #project/griddle "Save as View" button: prompts for name, saves current FilterSet to views list
- [x] #nextaction #project/griddle "Update View" option when a view is active (overwrite with current FilterSet)
- [x] #nextaction #project/griddle "Delete View" option per view
- [x] #nextaction #project/griddle Visual indicator when a view is active (highlighted/selected)

#### E) Persistence
- [x] #nextaction #project/griddle Include `views: View[]` in `DatasetFileV1` schema
- [x] #nextaction #project/griddle Include `activeFilterSet?: FilterSet` in app state (not persisted to file, runtime only)
- [x] #nextaction #project/griddle Update dataset export/import to handle views

#### F) Finish
- [x] #nextaction #project/griddle Update README: explain filters + views workflow
- [x] #nextaction #project/griddle Push commits and mark Milestone 8 complete

**Acceptance criteria:**
- User can open Filter Popup and set filters on any dimension
- Multiple dimension filters can be active simultaneously
- Filtered pivot updates live on apply
- User can save current filters as a named view
- User can switch between views from the hotbar
- Views persist with the dataset file
- UI resembles Excel pivot table filtering experience

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
- [x] #waitingfor #project/griddle Any additional example records / sample dataset (optional)

## Notes / Context
- Source thread: Discord #Structured JSON Editor (Griddle direction)
- Terminology (proposed): Dimensions (rows/cols), Slicers (true filters), Measures, Flags

### Future Enhancements / Backlog (captured in milestones below)
- [x] #nextaction #project/griddle Allow changing date format and data format overall within the griddle settings
- [x] #nextaction #project/griddle View full records in bulk edit
- [x] #nextaction #project/griddle In Style, select default for color so that we can have independent styling for font/background to reflect multiple metadata fields (combinatorics for each combination of metadata fields)
- [x] #nextaction #project/griddle Allow the date field type to autogenerate a given amount of dates
- [x] #nextaction #project/griddle Horizontal scrollbar for grid
- [x] #nextaction #project/griddle Add new rows/columns
- [x] #nextaction #project/griddle Create/Save views to allow ergonomic entry
- [x] #nextaction #project/griddle Ability to easily add fields to the .griddle file
- [ ] #nextaction #project/griddle Better saving UI so we don't have to download the file again to use it
- [x] #nextaction #project/griddle Should default to opening a griddle instead of what is saved locally
- [ ] #nextaction #project/griddle Figure out how settings for the griddle should work (within the file itself?)
- [ ] #nextaction #project/griddle Clean up UI
- [ ] #nextaction #project/griddle New Griddle Wizard (create new dataset: name + fields + initial pivot config; optional scaffold dates)
- [ ] #nextaction #project/griddle Default to a better starting screen where you choose to either create a new griddle or load an existing one

### Code Cleanup - Completed
- [x] #nextaction #project/griddle Remove dead spike files (AgGrid, Glide spike, MUI spike adapters)
- [x] #nextaction #project/griddle Remove unused components (DatasetImportExport, FastDetailsForm, FastEntryForm, GlidePivotHeader, SelectionInspector)
- [x] #nextaction #project/griddle Verify all tests pass after cleanup
- [x] #nextaction #project/griddle Verify build succeeds after cleanup
