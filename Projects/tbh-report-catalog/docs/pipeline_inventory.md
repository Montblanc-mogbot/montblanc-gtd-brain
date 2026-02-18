# Pipeline Inventory (Datasets + Reports)

This file is the durable index of *what the pipeline produces* at each stage.

Conventions:
- **Normalized** = one row per entity (tickets, orders, invoices, etc.). No duplicated money across grains.
- **Analytics** = answer-oriented datasets derived from normalized (safe to aggregate for CFO KPIs).
- **Reports** = Excel packs.

---

## Source tables currently available (dummy DB)
- Dispatch: `TICK`, `TKTL`, `TKTC`, `ORDR` (and `ORDL` exists but is legacy)
- AR: `ITRN`, `ARTB`
- GL: `GLDT`
- Reference: `PLNT`, `CUST`, `IMST`, `UOMS`

---

## Normalized outputs (Layer 2)

### Master data
- **Plants.csv** — 1 row per plant
- **Customers.csv** — 1 row per customer
- **Items.csv** — 1 row per item
- **Uoms.csv** — 1 row per UOM

### Dispatch entities
- **Orders.csv** — 1 row per order
  - includes derived: `ticket_count`
- **Tickets.csv** — 1 row per ticket
  - includes link: `invc_code` (nullable)
  - includes derived ticket-grain amounts: `ticket_product_amt`, `ticket_charge_amt`, `ticket_dispatch_total_amt`
  - includes derived status: `invoice_paid_in_full` (nullable)
- **TicketLines.csv** — 1 row per ticket line

### Billing / AR entities
- **InvoiceTransactions.csv** — 1 row per ITRN transaction (narrow)
- **Invoices.csv** — 1 row per invoice
  - invoice totals (sales/tax/total)
  - open balance + paid flag
  - dates (invoice/due/latest payment when available)

---

## Analytics outputs (Layer 3)

### A) Throughput / demand (ready-mix core)

#### 1) Throughput by day & plant (core pacing)
- **DispatchPlantDay.csv** *(exists today)*
  - grain: `day, plant_code`
  - metrics: `concrete_cy`, `loads (ticket_count)`, `dispatch_revenue`, `unique_truck_count`, `avg_cy_per_load`, `avg_revenue_per_load`
  - notes: `dispatch_revenue` should be based on ticket totals (`TKTL+TKTC`) via Tickets.csv

#### 2) Throughput by month & plant (board-level rollup)
- **DispatchPlantMonth.csv** *(to add)*
  - grain: `month, plant_code`
  - metrics: totals + averages mirroring DispatchPlantDay

#### 3) Revenue by source (dispatch vs GL)
- **RevenueBridge_MonthPlant.csv** *(to add; requires GL revenue account filter)*
  - grain: `month, plant_code`
  - metrics:
    - `dispatch_revenue`
    - `ar_revenue` (from invoices)
    - `gl_revenue` (from GLDT filtered to revenue accounts)
    - `dispatch_minus_gl`, `ar_minus_gl`

### B) Capacity & utilization (truck/plant utilization)

#### 1) Truck utilization by truck-day (best building block)
- **TruckUtilization_TruckDay.csv** *(to add)*
  - grain: `day, ship_plant_code, truck_code`
  - metrics:
    - `loads`
    - `concrete_cy`
    - `dispatch_revenue`
    - `truck_day_flag` (=1)
    - derived: `loads_per_truck_day` (=loads), `cy_per_truck_day` (=concrete_cy)

#### 2) Truck utilization by truck-month
- **TruckUtilization_TruckMonth.csv** *(to add)*
  - grain: `month, ship_plant_code, truck_code`
  - metrics:
    - `truck_days` (distinct truck-day)
    - `loads`
    - `concrete_cy`
    - derived: `loads_per_truck_day`, `cy_per_truck_day`

#### 3) Plant shipping days / capacity view
- **PlantShippingDays_Month.csv** *(to add)*
  - grain: `month, plant_code`
  - metrics:
    - `shipping_days` (days with concrete_cy>0 or loads>0)
    - `truck_days` (distinct truck-day)
    - `loads`, `concrete_cy`

### C) Service / reliability

> We have many timestamps available in `TICK` (load/to_job/on_job/begin_unld/end_unld/to_plant/at_plant). We should normalize the subset we trust, then compute cycle time analytics.

#### 1) Ticket cycle times (per ticket)
- **ServiceCycleTimes_Ticket.csv** *(to add; requires timestamp normalization)*
  - grain: ticket
  - fields:
    - timestamps
    - minutes: load_time, travel_to_job, on_job, unload, return_to_plant, total_cycle

#### 2) On-time delivery
- **OnTimeDelivery_DayPlant.csv** *(to add; requires scheduled vs actual time fields)*
  - grain: `day, plant`
  - metrics: `loads`, `on_time_loads`, `on_time_pct`, avg minutes late/early

#### 3) Cancellations/voids & same-day fulfillment proxies
- **TicketStatusSummary_DayPlant.csv** *(to add)*
  - grain: `day, plant`
  - metrics: counts by `tkt_status`, `remove_rsn_code` where present

### D) Quality / waste / rework

#### 1) Internal / botched loads (THOM06)
- **InternalLoads_Detail.csv** *(to add)*
  - grain: ticket
  - filter: customer_code == THOM06 (via Orders join)
  - fields: ticket identifiers, plant, truck, amounts, remove/cancel reasons, freeform notes fields if available

#### 2) Internal loads rollup
- **InternalLoads_MonthPlant.csv** *(to add)*
  - grain: `month, plant`
  - metrics: `internal_loads`, `internal_cy`, `internal_dispatch_revenue`

---

## AR / customer scoreboard analytics

### Invoice aging snapshot
- **InvoiceAging_ByInvoice.csv** *(to add; "as-of run" semantics)*
  - grain: invoice
  - fields:
    - `asof_date`
    - `invc_code`, `cust_code`, `invc_date`
    - `open_balance_amt`
    - `terms_class` (net30_assumed vs net15)
    - `assumed_due_date`
    - `days_outstanding`, `days_past_due`, `aging_bucket`

### Customer scoreboard rollups
- **CustomerScoreboard_Month.csv** *(to add)*
  - grain: `month, cust_code`
  - metrics:
    - sales (dispatch/ar)
    - open balance
    - weighted avg days outstanding
    - % past due

---

## Reports (Layer 4)
- **DispatchBilling Verification Pack.xlsx** *(exists today)*
- (future) **Plant Performance Pack.xlsx**
- (future) **Truck Utilization Pack.xlsx**
- (future) **Customer Scoreboard Pack.xlsx**
