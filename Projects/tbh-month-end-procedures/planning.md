# TBH Month End Procedures - Planning Document

**Created:** 2026-02-16  
**Status:** Awaiting Matt input on Python scripts

---

## 1. Current Workflow Documentation (Pending)

*To be filled in once Matt shares Python script structure*

### Data Sources
- [ ] Database connection details (abstracted)
- [ ] Query logic / data extraction steps
- [ ] Output formats (reports, files, etc.)

### Process Steps
1. *(TBD)*
2. *(TBD)*
3. *(TBD)*

### Tools/Scripts Used
- [ ] Python scripts (awaiting overview)
- [ ] Any external tools/services

---

## 2. Sensitive vs. Generalizable Parts (Pending Matt Confirmation)

| Category | Examples | Handling |
|----------|----------|----------|
| **Sensitive (Keep Offline)** | Account numbers, EINs, bank details, SSNs, credentials | Store in secure location only |
| **Generalizable (Can Document)** | Process steps, calculation logic, deadline schedules | Include in this repo |

---

## 3. State Filing Requirements Research (Pending Web Search Fix)

### Maryland (MD)
- **Sales Tax:**
  - Filing frequency: Monthly
  - Due date: 20th of following month
  - Portal: [bFile Maryland](https://interactive.marylandtaxes.gov/webapps/comptrollercra/entrance.asp)
- **Use Tax:** *(to research)*
- **Withholding:** *(to research)*

### West Virginia (WV)
- **Sales Tax:** *(to research)*
- **Use Tax:** *(to research)*
- **Withholding:** *(to research)*

### Pennsylvania (PA)
- **Sales Tax:** *(to research)*
- **Use Tax:** *(to research)*
- **Withholding:** *(to research)*

### Virginia (VA)
- **Sales Tax:** *(to research)*
- **Use Tax:** *(to research)*
- **Withholding:** *(to research)*

---

## 4. Proposed Process Improvements

*To be determined after workflow documentation complete*

---

## 5. Action Items

- [ ] Matt: Share Python script overview (structure, not credentials)
- [ ] Matt: Confirm sensitivity boundaries
- [ ] Montblanc: Research state filing requirements (pending web search fix)
- [ ] Montblanc: Create sanitized process diagram
- [ ] Montblanc: Design redacted/automated version

---

## Notes

- **API Issue:** Web search failing with `SUBSCRIPTION_TOKEN_INVALID` — Matt may need to check Brave Search API key in OpenClaw config
