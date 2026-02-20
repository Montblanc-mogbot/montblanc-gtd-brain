# Griddle — Pivot Spec (v1)

## Inputs
- `records: RecordEntity[]`
- `schema: DatasetSchema`
- `pivotConfig`

```ts
export interface PivotConfig {
  rowKeys: string[];    // dimension field keys
  colKeys: string[];    // dimension field keys
  slicerKeys: string[]; // optional

  slicers: Record<string, unknown>; // selected slicer values

  measureKey: string; // active measure to display
}
```

## Layout requirements (matches mock)
- Multiple **row dimensions** render as **one left-side column per row field**.
- Multiple **column dimensions** render as **stacked header rows** (one header row per col field) with appropriate `colSpan` grouping.
- Body cells show the aggregation for the active measure.

## Cell identity
A cell is uniquely determined by a row tuple + col tuple:

```ts
export type Tuple = Record<string, string>; // key -> value

export interface PivotCellKey {
  row: Tuple;
  col: Tuple;
}
```

## Output contract
The compute step returns a structure that makes rendering deterministic:

```ts
export interface PivotResult {
  rowTuples: Tuple[]; // distinct combos in rowKeys order
  colTuples: Tuple[]; // distinct combos in colKeys order

  // map: `${rowIndex}:${colIndex}` -> cell
  cells: Record<string, PivotCell>;
}

export interface PivotCell {
  value: number | null;      // SUM(measure) for matching records
  recordIds: string[];       // for "view full records" later
  flagSummary?: {
    // optional future: counts of true flags for contributing records
    [flagKey: string]: number;
  };
}
```

## Aggregation (v1)
- Only `SUM` for the chosen measure.
- Non-numeric or missing measure values are ignored.

## Selection hooks
When a user clicks a cell, the UI should be able to provide:
- implied dimension values (row tuple + col tuple)
- contributing `recordIds[]`

No record editing is required in this milestone.
