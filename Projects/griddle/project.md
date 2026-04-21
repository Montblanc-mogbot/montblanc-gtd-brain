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
- last_thread_digest_at: 2026-03-27T12:22-04:00

## Thread digest
- 2026-03-27: Matt confirmed the revert of the side-panel change is authoritative. Canonical repo location is `/home/montblanc/repos/griddle`; stale duplicate repo under archived `workspace-work` should not be used as a source of truth.
- 2026-03-27: Project-specific todos should live in this hub rather than Inbox.

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
- Heartbeat / execution preference: treat this Griddle stabilization plan as the active workstream when Griddle is the selected project; the top unchecked `#nextaction` in this section is the intended next step.
- Recent review conclusion: domain layer is in decent shape, but the interaction layer is fragile. Primary stabilization targets are `src/App.tsx`, panel/selection transitions, and Full Records complexity.
- Important repo reality: commit `3cd71a7` added fixed panel headers + click-off deselect, but it was later reverted by `31ff319`. The revert is authoritative; current `master` does **not** include that behavior.

## Next actions
- [x] #nextaction Stabilization pass 0: fix the current lint failure in `src/components/BulkMetadataEdit.tsx`, then re-run `npm run lint`, `npm test`, and `npm run build` until the repo is back to a clean green baseline. Review any changes for anything that might introduce bugs, especially hook ordering, render timing, and panel-related regressions. — DONE: moved `measureDecimals` `useMemo` above the early return so hooks are called unconditionally; no intended behavior change. Evidence: lint passes; tests pass (11/11); build passes on 2026-04-20. Bug review: low-risk fix; checked for stale dependency issues and no new panel/selection behavior changes were introduced. Remaining non-blocking warnings: third-party Rollup PURE comment warnings from `@glideapps/glide-data-grid` and existing large bundle chunk warning (~603 kB main chunk).
- [x] #nextaction Document the current interaction model in a short repo doc (suggested: `docs/workspace-interaction-model.md`) covering `selected`, `gridSelection`, `panelMode`, `pendingPanelMode`, `fullRecordsRecordIds`, pointer gesture intent, and the allowed transitions between entry, bulk, and full-records flows. Review any changes for anything that might introduce bugs, especially incorrect state assumptions, missing transition cases, or behavior drift from the actual app. — DONE: added `docs/workspace-interaction-model.md` documenting core selection/panel state, pointer gesture rules, and allowed transitions between entry, bulk, and full-records flows. Evidence: repo doc added on 2026-04-21; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Risk review: doc-only change; no runtime behavior changed.
- [ ] #nextaction Refactor `src/App.tsx` interaction handling so repeated selection/panel reset logic is centralized behind named helpers or a reducer-backed controller (`clearWorkspaceSelection`, `openFullRecordsFromBulk`, etc.) before attempting more UX changes. Review any changes for anything that might introduce bugs, especially invalid state combinations, stale selection context, keyboard navigation regressions, and pointer-up/pointer-down races.
- [ ] #nextaction Break up `src/components/FullRecordsPanel.tsx` into smaller pieces (header, table/body, draft/new-record handling, working-set behavior) and remove duplicated record mutation logic in favor of shared domain helpers. Review any changes for anything that might introduce bugs, especially edit persistence, draft row behavior, delete flows, working-set toggles, and selection continuity when moving between full-records and entry.
- [ ] #nextaction Add a shared regression checklist based on `docs/demo-dataset-workflow.md` for the known hotspot flows: single-cell → entry, range select → bulk, full-records open/close, same-cell reselection, toolbar/modal interactions while a panel is open, and any future click-off behavior. Review any changes for anything that might introduce bugs, especially missing smoke coverage for recent fixes or assumptions that leave old regressions untested.
- [ ] #nextaction Revisit side-panel UX polish only after the interaction model is clarified: fixed headers / scrollable bodies are still desirable, but any click-off deselect behavior must be scoped to the workspace and explicitly exclude top chrome, modals, and full-records interactions. Review any changes for anything that might introduce bugs, especially misclassified outside clicks, premature panel closure, modal interference, and full-records containment issues.
- [ ] #nextaction Prepare the validation UX milestone on top of the stabilized interaction layer by defining the validation state model, issue targeting rules, and how issue navigation maps into current selection/panel behavior before building the UI. Review any changes for anything that might introduce bugs, especially focus-jump edge cases, view-switch side effects, validation lag, and mismatches between issue paths and editable UI surfaces.
- [ ] #nextaction #waitingfor Matt: Share top 3 pain points from your current Griddle usage (links/screenshots ok). I’ll convert them into GitHub issues.
## Completed planning / historical context
- [x] Pick next milestone theme (import/export hardening vs validation UX vs performance). — PICKED: validation UX + workflow clarity next. Rationale: Milestone 8 finished (views/filters), next biggest ROI is making schema validation understandable/actionable during data entry and import, which will also surface the right follow-on performance work.
- [x] Create a concise Validation UX plan: error panel, inline field highlights, and “jump to next error” flow. — DONE (see “Validation UX plan” section below).
- [x] Add a tiny “demo dataset + expected workflow” doc to make regressions obvious. — DONE: `docs/demo-dataset-workflow.md` (commit 6af1beb)

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
