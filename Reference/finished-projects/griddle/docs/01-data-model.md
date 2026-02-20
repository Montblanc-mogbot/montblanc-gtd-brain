# Griddle — Data Model (v1)

## Storage principle
Pivot is a view. The only persisted truth is a flat list of records + a schema.

## Dataset JSON file
```ts
export interface DatasetFileV1 {
  version: 1;
  name: string;
  schema: DatasetSchema;
  records: RecordEntity[];
}
```

## Schema / fields
```ts
export type FieldRole = "rowDim" | "colDim" | "slicer" | "measure" | "flag";

export type FieldType = "string" | "number" | "boolean" | "date";

export interface FieldDef {
  key: string;   // stable identifier: "plant", "date", "quantity"
  label: string; // UI label
  type: FieldType;
  roles: FieldRole[];

  // optional categorical helpers
  enum?: string[];

  // measures
  measure?: {
    format?: "decimal" | "integer" | "currency";
  };

  // flags
  flag?: {
    style?: {
      cellClass?: string;
      priority?: number;
    };
  };
}

export interface DatasetSchema {
  version: 1;
  fields: FieldDef[];
}
```

## Record entity
```ts
export interface RecordEntity {
  id: string; // uuid
  createdAt: string; // ISO datetime
  updatedAt: string; // ISO datetime
  data: Record<string, unknown>; // schema keys live here
}
```

## Date decision
- Store as **date-only** string: `YYYY-MM-DD`
- Treat as categorical for v1 (no ranges, no bucketing)

## Number formatting decision
- No global preference; use per-field formatting metadata when present; otherwise default rendering.
