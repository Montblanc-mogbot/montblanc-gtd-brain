# CFO Report Layout — Dispatch vs Billing (Draft)

**Purpose:** Give the CFO a month-by-month view of what was *operationally delivered* (Dispatch) vs what was *financially billed/recognized* (Billing/AR), with reconciliation buckets that explain the gap.

This is intentionally an **explainable** report: every variance number should be traceable to a small list of underlying records.

---

## 1) Executive Summary (1 page)

### KPI Strip (top row)
For selected period (Month / Date range):
- Dispatch Gross $ (ticket/dispatch price)
- Billing Gross $ (invoiced)
- Variance $ and Variance %
- Dispatch Volume (tons/yds) + count of tickets
- Billed Volume + count of invoices
- Avg $/ton (dispatch) vs (billing)

### Waterfall: Dispatch → Billing
A variance waterfall that explains the gap:
- Dispatch Gross
- Less: Not Invoiced Yet (cutoff / timing)
- +/- Adjustments (credits/debits)
- +/- Price Overrides / Ticket Edits
- +/- Non-dispatch Billing (fees, finance charges, misc)
- = Billing Gross

### Variance Health
- Explained variance % (target high)
- Unexplained variance % (target < 2%)

---

## 2) Reconciliation Detail (drillable)

### Table: Variance Buckets
| Bucket | $ Amount | Count | Notes | Drilldown Key |
|-------|----------:|------:|------|---------------|
| Cutoff (Dispatched not invoiced) | | | | ticket_id / invc_code |
| Credits / Returns | | | | invc_code / adj_code |
| Price differences | | | | ticket_id + invc_code |
| Fees / Misc billing | | | | invc_code |
| Tax differences | | | | invc_code |
| Other | | | | |

### Drilldown pages
Each bucket should open a filtered detail list:
- For cutoff: dispatched tickets missing invoices (or invoiced in subsequent period)
- For credits: credit memos / negative adjustments
- For price: matched dispatch lines vs invoice lines with deltas

---

## 3) Plant / Customer Slices

### Plant slice
| Plant | Dispatch $ | Billing $ | Var $ | Var % | Dispatch Tons | Billing Tons |

### Customer slice
| Customer | Dispatch $ | Billing $ | Var $ | Notes |

Optional: Top N customers by variance.

---

## 4) Data Requirements (minimum viable)

### From Dispatch side
- ticket identifier(s)
- ticket date (dispatch date)
- ship plant code
- customer code
- delivered qty + UOM
- extended price (dispatch)
- material cost (if available)

### From Billing/AR side
- invoice code
- invoice date
- customer code
- pre-tax amount, tax amount, total
- adjustment / payment indicators (if present)

---

## 5) How this maps to current ITRN export (initial spike)

The provided ITRN CSV is treated as **raw Billing/AR-ish** source until we confirm exact meaning.

Key candidate fields:
- `trans_date`, `batch_date`
- `cust_code`, `ship_cust_code`
- `plant_code`
- `pretax_amt`, `tax_amt`, `check_amt`, `pmt_amt`
- `invc_code`, `ar_adj_code`

Next step after load:
- Build a lightweight SQLite view that aggregates by month + plant + customer using the above fields.

---

## 6) Open Questions for Matt

1. In ITRN, what exactly does `pretax_amt` represent (invoice total pre-tax? line? transaction?)
2. Are `invc_code` values unique per invoice in the export?
3. What table(s) represent Dispatch delivered totals (ticket lines) for the same period?
4. What is the authoritative source for "billed revenue" — ITRN, invoices table, or GL?
