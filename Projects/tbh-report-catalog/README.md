# TBH Report Catalog

C# reporting tool for TBH — bridging Command Alkon (Dispatch) and GL (Accounting) data.

## Architecture

Four-layer data pipeline based on industry best practices:

```
Layer 1: Extract        Layer 2: Normalize      Layer 3: Analytics      Layer 4: Reports
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│ Command Alkon   │───→│ Plant codes     │───→│ Plant           │───→│ Excel           │
│   - slsd        │    │ Date alignment  │    │ Performance     │    │   Executive     │
│   - plnt        │    │ UOM standard    │    │   - Volume      │    │   Operations    │
│   - tkt/tktd    │    │                 │    │   - Revenue     │    │                 │
│                 │    │                 │    │   - Costs       │    │                 │
│ GL Database     │    │                 │    │ Reconciliation  │    │                 │
│   (future)      │    │                 │    │   (future)      │    │                 │
└─────────────────┘    └─────────────────┘    └─────────────────┘    └─────────────────┘
```

### Key Principles

1. **Extract**: "What is in the system" — no business logic, just raw data
2. **Normalize**: "Explainable to an auditor in plain English" — stable business rules
3. **Analytics**: "Each dataset answers one business question well"
4. **Reports**: Excel as primary interface — static for executives, interactive for operations

## Project Structure

```
src/
├── Tbh.Extract/          # Layer 1: Data extraction interfaces
│   ├── Interfaces/
│   │   └── ICommandAlkonExtractor.cs
│   └── Models/
│       └── CommandAlkon/
│           ├── PlantRecord.cs
│           └── SalesDetailRecord.cs
│
├── Tbh.Normalize/        # Layer 2: Data normalization
│   └── CommandAlkonNormalizer.cs
│
├── Tbh.Analytics/        # Layer 3: Analytical datasets
│   ├── Builders/
│   │   └── PlantPerformanceBuilder.cs
│   └── Models/
│       └── PlantPerformanceRecord.cs
│
└── Tbh.Reports/          # Layer 4: Excel generation
    └── Interfaces/
        └── IExcelReportGenerator.cs

Tbh.ReportCatalog/        # Main orchestrator
├── ReportCatalogOrchestrator.cs
└── Program.cs
```

## Usage

### Building

```bash
dotnet build TbhReportCatalog.sln
```

### Running

```bash
dotnet run --project src/Tbh.ReportCatalog
```

## Implementation Status

### ✅ Completed
- [x] Project skeleton with layered architecture
- [x] Extract interfaces (ICommandAlkonExtractor)
- [x] Normalization logic (plant codes, date alignment)
- [x] Plant Performance analytical dataset model
- [x] Report generation interface

### 🔄 Next Steps
- [ ] Implement `ICommandAlkonExtractor` (you write SQL queries)
- [ ] Implement `IExcelReportGenerator` (Excel formatting with EPPlus)
- [ ] Add sample data for testing
- [ ] Build reconciliation view (Command vs GL)

## Data Sources

### Command Alkon — Primary Tables

**Design Decision:** Use `slsd` as the **primary source** for volume, revenue, and costs because it matches the Command reports that the board will compare against.

| Table | Purpose | Key Fields | Priority |
|-------|---------|------------|----------|
| `slsd` | **Sales detail (PRIMARY SOURCE)** | `ship_plant_code`, `tkt_date`, `delv_qty`, `ext_price_amt`, `ext_matl_cost_amt` | Required |
| `plnt` | Plant master | `plant_code`, `name`, `short_name` | Required |
| `cust` | Customer master | `cust_code`, `name`, `sort_name` | Required |
| `imst` | Item/product master | `item_code`, `descr`, `item_cat` | Required |
| `ordr` | Order headers | `order_date`, `order_code`, `cust_code`, `proj_code` | Validation |
| `ordl` | Order lines | `delv_qty`, `price` | Validation |
| `tktc` | Ticket charges | `ext_price_amt`, `ext_matl_cost_amt` | Validation |
| `proj` | Project master | `proj_code`, `proj_name` | Drill-down |

### GL Database — Future Integration

Pending schema documentation.

## Security Notes

- Database credentials stored in configuration (not code)
- Extract interfaces designed for clean SQL review before execution
- All raw exports saved for audit trail
- No sensitive data hardcoded in repository

## License

Internal use only — TBH Company
