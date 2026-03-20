# Griddle (Structured JSON Editor)

## TL;DR
Schema-driven pivot table + data entry tool (Structured JSON Editor UI).

## Repo
- `/home/montblanc/repos/griddle`
  - GitHub: https://github.com/Montblanc-mogbot/griddle

## Discord thread
- Thread/channel link/id: channel:1469349466468389143  ("Structured JSON Editor")

## Pulse tracking (anti-spam)
- last_pulse_at: 2026-03-18T10:08
- last_pulse_message_id: 1483829453539905667
- awaiting_matt: true

## Context / where notes live
- Project hub (this file)
- Repo docs/issues

## Goals
- Fast, reliable schema-driven editing
- Good UX for pivoting + data entry

## What done looks like
- Views/filters system stable
- Clear “create/edit” flows
- Export/import safe and documented

## Current status
- Milestone 8 complete; filters + views system done; awaiting user feedback.

## Next actions
- [x] #nextaction Fix side panels: keep close button always visible (header not scrollable), and add background click handler to deselect grid + close side panel. Then push to GitHub pages. (Thread: Structured JSON Editor 2026-03-20) — DONE: drawer no longer scrolls; panels have fixed header + scrollable body; click outside grid+drawer clears selection + closes panel. Evidence: griddle commit `3cd71a7` (pushed).
- [ ] #nextaction #waitingfor Matt: Share top 3 pain points from your current Griddle usage (links/screenshots ok). I’ll convert them into GitHub issues.
- [x] #nextaction Pick next milestone theme (import/export hardening vs validation UX vs performance). — PICKED: validation UX + workflow clarity next. Rationale: Milestone 8 finished (views/filters), next biggest ROI is making schema validation understandable/actionable during data entry and import, which will also surface the right follow-on performance work.
- [x] #nextaction Create a concise Validation UX plan: error panel, inline field highlights, and “jump to next error” flow. — DONE (see “Validation UX plan” section below).
- [x] #nextaction Add a tiny “demo dataset + expected workflow” doc to make regressions obvious. — DONE: `docs/demo-dataset-workflow.md` (commit 6af1beb)

## Validation UX plan (concise)

### Goals
- Make it obvious **what’s wrong**, **where**, and **what to do next**.
- Keep the editor fast: validation feedback should not block typing.
- Support both workflows:
  - **Data entry** (incremental edits)
  - **Import** (batch JSON → many errors)

### Error model (data contract)
Represent each validation issue as:
- `id`: stable string (hash of path + rule + message)
- `severity`: `error` | `warning`
- `path`: JSONPath-ish pointer to the field (e.g. `/customers/3/email`)
- `message`: human-readable
- `rule`: optional machine code (e.g. `required`, `minLength`, `enum`)
- `suggestion`: optional “what to do” hint

### UI components
1) **Validation panel (right sidebar or bottom drawer)**
   - Shows summary: `Errors (N)`, `Warnings (M)`
   - List items show: severity icon, short message, and truncated path
   - Controls:
     - Search/filter by text
     - Toggle show warnings
     - Group by: `Section` (top-level object) or `Path prefix`
     - “Collapse all / expand all” (if grouped)
   - Each list item is clickable → navigates & focuses the field.

2) **Inline field highlights**
   - Any cell/field with an issue gets:
     - Red outline (errors) / amber outline (warnings)
     - Small indicator (dot/triangle) so it’s visible even when compact
   - On hover/focus: show tooltip with full message + suggestion.

3) **Jump controls**
   - In panel header: `Prev` / `Next` buttons to jump between issues.
   - Keyboard:
     - `F8` = next issue (common convention)
     - `Shift+F8` = previous issue
     - Optional: `Ctrl+Enter` to “fix & continue” for simple autofixes later

### “Jump to next error” flow (focus + scroll rules)
- When user clicks an issue or presses jump hotkey:
  1. Compute target **view + row + field** for `path`.
  2. If current view can’t display it (filtered out / different pivot):
     - Show a small prompt: “This error is outside the current view. Switch views?”
     - One-click: “Switch and jump” (non-destructive; preserve current view in history)
  3. Scroll grid to row; scroll horizontally to column.
  4. Focus the cell and open the editor.
  5. Announce via aria-live: “Error 3 of 12: <message>”.

### When to validate
- **On edit (debounced):** validate the edited node after ~200–300ms idle.
- **On blur/commit:** validate immediately.
- **On import:** validate whole document, but render incrementally (virtualize the panel list).

### Progressive disclosure / avoiding overwhelm
- Default panel shows **errors only**; warnings behind a toggle.
- In-grid: show highlights, but avoid big inline text until focus.
- Cap inline tooltip text length; link “Show details” (expands in panel).

### Performance notes
- Keep validation results in a normalized store keyed by `path`.
- For large docs, avoid full re-validate on each keystroke; validate by subtree when possible.
- Panel list must be virtualized (e.g., react-window) when many issues.

### Acceptance criteria
- With 50+ errors after import:
  - Panel remains responsive (scrolling smooth)
  - Jump next/prev reliably focuses correct field
- With normal typing:
  - No keystroke lag attributable to validation UI
