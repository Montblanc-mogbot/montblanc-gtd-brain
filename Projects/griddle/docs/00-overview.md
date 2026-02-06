# Griddle — Overview

## Problem
A schema-driven data-entry tool for categorical-heavy records (Bills of Lading / ledger entries) with a pivot-table-like view.

- Records are entered via forms (sidebar / full editor later)
- Pivot view is a **derived view** over flat records
- Fields are flexible: no required fields by default

## Key Concepts
- **Dataset**: `records[]` + `schema` (field definitions)
- **Dimensions**: categorical/date fields assigned to **Rows** and **Columns**
- **Slicers** (optional): true filters that restrict which records contribute to the pivot
- **Measures**: numeric fields aggregated into cell values (v1: SUM)
- **Flags**: boolean metadata that changes formatting/highlighting

## V1 Scope (Pivot Milestone)
- Load/save dataset JSON (in-memory is fine initially)
- Choose row/column dimensions
- Choose active measure from dropdown
- Render pivot grid (tabular pivot like provided mock)
- Cell selection returns:
  - implied dimension values (row tuple + col tuple)
  - `recordIds[]` contributing to that cell

## Non-goals for V1
- Date bucketing (week/month/year)
- Complex aggregation selection (avg/min/max)
- Full record entry/edit UI (we only lay hooks)
