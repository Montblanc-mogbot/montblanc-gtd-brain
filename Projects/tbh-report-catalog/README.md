# TBH Report Catalog

A normalized reporting architecture spanning Dispatch and Accounting systems for CFO-ready executive reports and drillable operations reports.

## Problem Statement

**Current State:**
- Treasurer isn't focused on reporting/analytics
- Two systems of record (Dispatch DB + Accounting DB) that don't always agree
- No clear distinction between operational reality and financial recognition
- Excel is the primary interface, but ad-hoc and inconsistent

**Goal:**
- Clear, trustworthy data for CFO decision-making
- Normalized data pipeline that reconciles operational vs. financial truth
- Handoff-ready documentation for stepping into the CFO role

---

## Architecture Overview

### Layered Data Pipeline

```
┌─────────────────────────────────────────────────────────────────┐
│                        PRESENTATION LAYER                        │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────────────┐  │
│  │   Executive  │  │  Operations  │  │   Reconciliation     │  │
│  │   Reports    │  │   Reports    │  │      Reports         │  │
│  │  (CFO view)  │  │ (Drillable)  │  │  (System alignment)  │  │
│  └──────────────┘  └──────────────┘  └──────────────────────┘  │
└─────────────────────────────────────────────────────────────────┘
                              ▲
                              │
┌─────────────────────────────────────────────────────────────────┐
│                     ANALYTICAL DATASETS                          │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────────────┐  │
│  │   Revenue    │  │    Plant     │  │      Dispatch        │  │
│  │   Analysis   │  │  Performance │  │     Efficiency       │  │
│  └──────────────┘  └──────────────┘  └──────────────────────┘  │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────────────┐  │
│  │   Monthly    │  │   Material   │  │    Customer          │  │
│  │   P&L by     │  │   Margin     │  │    Profitability     │  │
│  │    Plant     │  │   Analysis   │  │                      │  │
│  └──────────────┘  └──────────────┘  └──────────────────────┘  │
└─────────────────────────────────────────────────────────────────┘
                              ▲
                              │
┌─────────────────────────────────────────────────────────────────┐
│                      NORMALIZATION LAYER                         │
│  • Plant code standardization (DS → Downtown, etc.)              │
│  • Material name mapping (3/4" Stone → Three Quarter Stone)      │
│  • Customer name normalization                                   │
│  • Unit of measure standardization                               │
│  • Date/period alignment                                         │
└─────────────────────────────────────────────────────────────────┘
                              ▲
                              │
┌─────────────────────────────────────────────────────────────────┐
│                      EXTRACTION LAYER                            │
│  ┌────────────────────┐        ┌────────────────────┐           │
│  │   DISPATCH SYSTEM  │        │  ACCOUNTING SYSTEM │           │
│  │  ───────────────── │        │  ───────────────── │           │
│  │  • Tickets         │        │  • Invoices        │           │
│  │  • Loads           │        │  • Payments        │           │
│  │  • Plant activity  │        │  • AR/AP           │           │
│  │  • Truck/crew logs │        │  • GL entries      │           │
│  │  • Customer calls  │        │  • Cost data       │           │
│  └────────────────────┘        └────────────────────┘           │
└─────────────────────────────────────────────────────────────────┘
```

---

## Design Principles

### 1. One Dataset, One Question
Each analytical dataset answers ONE business question well. Don't try to make a single report answer everything.

### 2. Explainable Data
Every normalized value must be explainable to an auditor in plain English. Keep a "normalization log" that documents:
- Source value
- Target value
- Transformation rule
- Business justification

### 3. Reconciliation, Not Forced Agreement
Operational truth (Dispatch) and financial truth (Accounting) don't need to match immediately. The reconciliation layer exists to:
- Identify differences
- Explain timing or classification gaps
- Track resolution

### 4. Excel-First, But Structured
Excel remains the primary interface for accessibility, but:
- Standardized templates
- Protected formulas
- Clear data sources documented
- Version control for templates

---

## Analytical Datasets (Proposed)

| Dataset | Source | Question Answered | Primary User |
|---------|--------|-------------------|--------------|
| **Revenue Analysis** | Accounting + Dispatch | "How much revenue did we recognize, and when?" | CFO |
| **Plant Performance** | Dispatch | "Which plants are most productive?" | Operations Manager |
| **Dispatch Efficiency** | Dispatch | "Are we maximizing truck/capacity utilization?" | Dispatch Manager |
| **Monthly P&L by Plant** | Accounting | "Which plants are profitable?" | CFO |
| **Material Margin Analysis** | Accounting + Dispatch | "Which materials have best margins?" | CFO |
| **Customer Profitability** | Accounting + Dispatch | "Which customers are most/least profitable?" | Sales/CFO |
| **AR Aging by Customer** | Accounting | "Who owes us money and for how long?" | CFO |
| **Reconciliation: Dispatched vs. Invoiced** | Both | "What was delivered but not yet billed?" | CFO |

---

## Data Reconciliation Framework

### Common Discrepancies

| Type | Cause | Example | Resolution |
|------|-------|---------|------------|
| **Timing** | Invoice lag | Load dispatched 1/31, invoiced 2/2 | Track as "cutoff variance" |
| **Classification** | Different plant codes | "DS" vs "Downtown" | Normalization mapping |
| **Data entry** | Manual errors | Wrong material on ticket | Correction workflow |
| **Scope** | Different record sets | Cancelled loads in Dispatch only | Document exclusion rules |

### Reconciliation Report Template

```
Period: [Month/Year]

DISPATCH TOTALS:
  - Total Loads: [X]
  - Total Tons: [Y]
  - Total Revenue (at ticket prices): $[Z]

ACCOUNTING TOTALS:
  - Total Invoices: [A]
  - Total Tons Billed: [B]
  - Total Revenue Recognized: $[C]

VARIANCE ANALYSIS:
  ┌──────────────────────┬─────────────┬─────────────────────────────┐
  │ Category             │ Amount      │ Explanation                 │
  ├──────────────────────┼─────────────┼─────────────────────────────┤
  │ Cutoff (timing)      │ $[X]        │ [Details]                   │
  │ Classification       │ $[Y]        │ [Details]                   │
  │ Data corrections     │ $[Z]        │ [Details]                   │
  │ Other                │ $[W]        │ [Details]                   │
  ├──────────────────────┼─────────────┼─────────────────────────────┤
  │ TOTAL VARIANCE       │ $[V]        │                             │
  └──────────────────────┴─────────────┴─────────────────────────────┘

EXPLAINED VARIANCE: [V]% of total
UNEXPLAINED VARIANCE: [U]% of total (target: <2%)
```

---

## Normalization Rules (Examples)

### Plant Codes
| Source Value | Normalized Value | Notes |
|--------------|------------------|-------|
| DS | Downtown | Primary plant |
| N | North | Secondary plant |
| S | South | Secondary plant |
| WS | West Side | Secondary plant |

### Material Names
| Source Value | Normalized Value | Category |
|--------------|------------------|----------|
| 3/4" Stone | Three Quarter Stone | Aggregate |
| #57 Stone | Number Fifty-Seven Stone | Aggregate |
| Crusher Run | Crusher Run Base | Base Material |
| 3/8 Chips | Three Eighths Chips | Aggregate |

### Date Standardization
- All periods: YYYY-MM format
- Fiscal month ends: Last day of calendar month
- Cutoff time: 11:59 PM on last day of month

---

## File Structure

```
Projects/tbh-report-catalog/
├── README.md                    # This file
├── project.md                   # Project status and TODOs
├── architecture.md              # Detailed architecture docs
├── datasets/                    # Analytical dataset definitions
│   ├── revenue-analysis.md
│   ├── plant-performance.md
│   ├── dispatch-efficiency.md
│   └── ...
├── normalization/               # Normalization rules and mappings
│   ├── plant-codes.csv
│   ├── material-names.csv
│   └── customer-mappings.csv
├── extraction/                  # Python scripts for data pulls
│   ├── dispatch-extract.py
│   ├── accounting-extract.py
│   └── reconcile.py
├── reports/                     # Excel templates
│   ├── executive-summary.xlsx
│   ├── plant-performance.xlsx
│   └── reconciliation.xlsx
└── docs/                        # Additional documentation
    ├── cfo-handoff-guide.md
    └── data-dictionary.md
```

---

## Next Steps

1. **Finalize prioritization** — Which analytical datasets are needed first?
2. **Inventory existing scripts** — What Python extraction scripts already exist?
3. **Document current Excel reports** — What reports are currently being generated?
4. **Build first dataset** — Start with highest priority (suggest: Revenue Analysis or Plant Performance)

---

## Open Questions

1. What are the primary pain points with current reporting?
2. Which existing Excel reports should be migrated first?
3. What's the current process for month-end close?
4. Are there any data quality issues already known?

---

*Last updated: 2026-02-16*
