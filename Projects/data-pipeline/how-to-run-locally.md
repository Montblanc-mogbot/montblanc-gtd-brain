# Data Pipeline — How to run locally (TBH Report Catalog)

This project lives in:
- `/home/montblanc/repos/tbh-report-catalog`

## Pipeline layers (mental model)
See `docs/pipeline.md` for the definitions:
- Layer 0: source exports (raw CSVs)
- Layer 1: dummy DB (SQLite) for fast iteration
- Layer 2: normalized CSVs → `normalized/`
- Layer 3: analytics CSVs → `analytics/`
- Layer 4: reports → `reports/`

## Inputs

### Dummy DB (dev)
- Path: `data/command_alkon_dummy.db`
- This is used to iterate on schemas/normalization without connecting to Command Alkon.

### Source exports (optional / future)
- Not required for local dev if you use the dummy DB.

## Running the pipeline

### 0) Prereqs
- .NET SDK (repo builds via `dotnet`)

### 1) Normalize (Layer 2)
From repo root:

```bash
cd /home/montblanc/repos/tbh-report-catalog

# (pick the month prefix you want; sample data often uses 202501)
export TBH_MONTH=202501

dotnet run --project src/Tbh.Normalize/Tbh.Normalize.csproj -- $TBH_MONTH
```

Expected outputs:
- `normalized/${TBH_MONTH} Plants.csv`
- `normalized/${TBH_MONTH} Customers.csv`
- `normalized/${TBH_MONTH} Items.csv`
- `normalized/${TBH_MONTH} InvoiceTransactions.csv`
- `normalized/${TBH_MONTH} Tickets.csv`
- `normalized/${TBH_MONTH} TicketLines.csv`
- `normalized/${TBH_MONTH} Orders.csv`

If outputs are missing, check:
- the dummy DB exists (`data/command_alkon_dummy.db`)
- the normalize project has access to the DB path it expects (see config inside `src/Tbh.Normalize`)

### 2) Analytics (Layer 3)

```bash
cd /home/montblanc/repos/tbh-report-catalog
export TBH_MONTH=202501

dotnet run --project src/Tbh.Analytics/Tbh.Analytics.csproj -- $TBH_MONTH
```

Expected outputs:
- `analytics/${TBH_MONTH} DispatchPlantDay.csv`
- (others as added; see `docs/pipeline_inventory.md`)

### 3) Reports (Layer 4)

```bash
cd /home/montblanc/repos/tbh-report-catalog
export TBH_MONTH=202501

dotnet run --project src/Tbh.Reports/Tbh.Reports.csproj -- $TBH_MONTH
```

Expected outputs:
- files under `reports/` (report-specific)

## Environment variables / knobs

- `TBH_MONTH` (suggested convention): `YYYYMM` month prefix used for outputs.
- If you add any connection strings or real extract steps later, document them here.

## Debugging tips

- Confirm the month prefix you’re running matches files you’re inspecting.
- If analytics are empty, check whether normalization produced data and whether dummy DB is row-limited.
- Use `docs/pipeline_inventory.md` as the authoritative list of datasets.
