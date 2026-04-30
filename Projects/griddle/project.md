# Griddle (Structured JSON Editor)

## TL;DR
Schema-driven pivot table + data entry tool (Structured JSON Editor UI).

## Repo
- `/home/montblanc/repos/griddle`
  - Upstream GitHub: https://github.com/Montblanc-mogbot/griddle
  - Integration fork GitHub: https://github.com/Montblanc-mogbot/griddle-integration
  - Git remotes: `origin` = upstream, `fork` = integration fork
  - Active working branch: `stabilization-pass-1` (tracks `fork/stabilization-pass-1`)
  - **Workflow rule:** do not make future Griddle source changes directly on `origin/master`. Land Griddle work on the `fork` remote first, test there, then selectively merge upstream.

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
- Repo had uncommitted Griddle work in progress (`docs/demo-dataset-workflow.md`, `docs/workspace-interaction-model.md`, plus new `src/domain/validationTargeting*` files); this was pushed into the integration fork so future testing can happen there before upstream merges.
- Heartbeat / execution preference: treat this Griddle stabilization plan as the active workstream when Griddle is the selected project; the top unchecked `#nextaction` in this section is the intended next step.
- Deployment guardrail: heartbeat may commit, validate, and push normal source changes for Griddle, but it must **not** publish/deploy/push GitHub Pages or any user-facing release artifact for Griddle until Matt explicitly approves that release.
- Recent review conclusion: domain layer is in decent shape, but the interaction layer is fragile. Primary stabilization targets are `src/App.tsx`, panel/selection transitions, and Full Records complexity.
- Important repo reality: commit `3cd71a7` added fixed panel headers + click-off deselect, but it was later reverted by `31ff319`. The revert is authoritative; current `master` does **not** include that behavior.

## Next actions
- [x] #nextaction Create/configure a dedicated Griddle fork remote + working branch, then move the current local Griddle changes onto that fork/branch before any further Griddle implementation work. — DONE: created integration fork `Montblanc-mogbot/griddle-integration`, added git remote `fork`, and pushed current local state to `fork/master`.
- [x] #nextaction On branch `stabilization-pass-1`, review the current uncommitted Griddle validation-targeting/docs changes, run `npm run lint`, `npm test`, and `npm run build`, then commit and push them to `fork/stabilization-pass-1` as one focused checkpoint if validation passes. — DONE: reviewed and checkpointed the in-progress validation-targeting/docs work (`docs/demo-dataset-workflow.md`, `docs/workspace-interaction-model.md`, `src/domain/validationTargeting.ts`, `src/domain/validationTargeting.test.ts`) on `stabilization-pass-1`. Evidence: commit `a029202` (`Checkpoint validation targeting prep`) pushed to `fork/stabilization-pass-1`. Validation: `npm run lint`, `npm test`, and `npm run build` all passed on 2026-04-29. Bug review: this checkpoint keeps the new targeting helper pure/domain-only, preserves doc-only workflow notes, and introduced no runtime UI behavior changes beyond tested targeting classification logic.
- Workflow rule: Continue all Griddle implementation work on branch `stabilization-pass-1` against the `fork` remote first; only propose upstream merge/promotion after validation on the integration fork.
- [x] #nextaction Validation UX prep, slice 5: add a small pure helper that groups validation issues for panel presentation (for example by severity + top-level path prefix), plus focused unit tests. Keep it domain-only and additive; do not build UI yet. Review any changes for anything that might introduce bugs, especially overfitting grouping rules to speculative UI. — DONE: added pure grouping helper `groupValidationIssues(...)` to `src/domain/validationTargeting.ts`, added focused grouping tests in `src/domain/validationTargeting.test.ts`, and documented conservative grouping guidance in `docs/validation-state-model.md`. Evidence: commit `d03e0b3` (`Add validation issue grouping helper`) pushed to `fork/stabilization-pass-1`. Validation: `npm run lint`, `npm test`, and `npm run build` all passed on 2026-04-30. Bug review: kept grouping domain-only and deterministic (severity + top-level path prefix), avoided UI labels/layout assumptions, and sorted grouped issues by stable structural fields rather than render order.
- [x] #nextaction Validation UX prep, slice 6: add a pure helper that turns grouped validation issues into compact section summaries (counts + stable labels) for a future panel, plus focused unit tests and minimal doc notes if needed. Keep it domain-only and additive; no UI rendering yet. Review any changes for anything that might introduce bugs, especially inventing UI semantics that the current interaction model cannot support. — DONE: added pure summary helper `summarizeValidationIssueGroups(...)` to `src/domain/validationTargeting.ts`, added focused section-summary tests in `src/domain/validationTargeting.test.ts`, and extended `docs/validation-state-model.md` with conservative summary-helper guidance. Evidence: commit `0d8ad25` (`Add validation issue section summaries`) pushed to `fork/stabilization-pass-1`. Validation: `npm run lint`, `npm test`, and `npm run build` all passed on 2026-04-30. Bug review: kept labels machine-derived and reversible (`<severity>: <pathPrefix>`), preserved domain-only behavior with no UI rendering/state coupling, and avoided adding navigation semantics beyond existing grouping structure.
- [x] #nextaction Validation UX prep, slice 7: extend the manual validation workflow docs with a tiny checkpoint describing how grouped issue summaries should map back to Entry vs Full Records navigation without mutating filters or views. Keep it doc-only, bounded, and aligned with the existing targeting rules. — DONE: extended `docs/demo-dataset-workflow.md` with grouped-summary navigation checkpoint `7f`, covering when grouped validation summaries may honestly preserve/open Entry vs when they must fall back to Full Records without mutating filters, pivot layout, or saved views. Evidence: commit `d879d73` (`Document grouped validation navigation checkpoint`) pushed to `fork/stabilization-pass-1`. Validation: `npm run lint`, `npm test`, and `npm run build` all passed on 2026-04-30. Bug review: doc-only change; kept grouped-summary navigation explicitly subordinate to the existing issue-targeting rules and avoided implying any finished validation panel UI or auto-navigation semantics beyond honest Entry/Full Records fallback.
- [x] #nextaction Validation UX prep, slice 8: implement a tiny pure helper that classifies grouped-summary navigation conservatively (Entry vs Full Records vs dataset-only vs unresolved), plus focused unit tests and minimal doc notes. Keep it domain-only and additive; no UI rendering, filter mutation, or view mutation yet. Review any changes for anything that might introduce bugs, especially pretending a section summary can target an exact cell when it cannot. — DONE: added pure helper `classifyValidationSummaryNavigationTarget(...)` to `src/domain/validationTargeting.ts`, added focused tests in `src/domain/validationTargeting.test.ts`, and extended `docs/validation-state-model.md` with grouped-summary navigation helper guidance. Evidence: commit `0a73b39` (`Add grouped validation navigation helper`) pushed to `fork/stabilization-pass-1`. Validation: `npm test`, `npm run lint`, and `npm run build` all passed on 2026-04-30. Bug review: kept summary navigation conservative and machine-oriented, only allows Entry when the caller can already prove one record-backed visible field area, prefers Full Records over ambiguous jumps, and leaves dataset/missing-anchor cases unresolved rather than inventing brittle UI behavior.
- [x] #nextaction Stabilization pass 0: fix the current lint failure in `src/components/BulkMetadataEdit.tsx`, then re-run `npm run lint`, `npm test`, and `npm run build` until the repo is back to a clean green baseline. Review any changes for anything that might introduce bugs, especially hook ordering, render timing, and panel-related regressions. — DONE: moved `measureDecimals` `useMemo` above the early return so hooks are called unconditionally; no intended behavior change. Evidence: lint passes; tests pass (11/11); build passes on 2026-04-20. Bug review: low-risk fix; checked for stale dependency issues and no new panel/selection behavior changes were introduced. Remaining non-blocking warnings: third-party Rollup PURE comment warnings from `@glideapps/glide-data-grid` and existing large bundle chunk warning (~603 kB main chunk).
- [x] #nextaction Document the current interaction model in a short repo doc (suggested: `docs/workspace-interaction-model.md`) covering `selected`, `gridSelection`, `panelMode`, `pendingPanelMode`, `fullRecordsRecordIds`, pointer gesture intent, and the allowed transitions between entry, bulk, and full-records flows. Review any changes for anything that might introduce bugs, especially incorrect state assumptions, missing transition cases, or behavior drift from the actual app. — DONE: added `docs/workspace-interaction-model.md` documenting core selection/panel state, pointer gesture rules, and allowed transitions between entry, bulk, and full-records flows. Evidence: repo doc added on 2026-04-21; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Risk review: doc-only change; no runtime behavior changed.
- [x] #nextaction Extract `src/App.tsx` workspace selection/panel transitions into a first small helper layer with named functions for the already-repeated reset/open paths (`clearWorkspaceSelection`, `openFullRecordsFromBulk`, `openEntryFromSelection`, etc.) without changing behavior yet. Keep the change narrowly scoped to obvious duplication removal and state-transition naming. Review any changes for anything that might introduce bugs, especially invalid state combinations, stale selection context, and pointer-up/pointer-down races. — DONE: added small `src/App.tsx` helper functions for grid/workspace clearing plus entry/full-records opens, and routed repeated panel-transition call sites through them without changing the surrounding interaction model. Evidence: commit `ba2c063`; validation passed on 2026-04-22 via `npm run lint`, `npm test`, and `npm run build`. Bug review: kept behavior narrow by preserving existing pointer-down gating and panel-mode transitions; checked for invalid state combinations from clear helpers and for stale/full-records selection loss on bulk/entry close paths.
- [x] #nextaction Add targeted regression coverage for the first helper extraction pass: at minimum, document and/or codify smoke checks for clear-selection behavior, same-cell reselection, bulk → full-records open, and full-records close back to entry. Review any changes for anything that might introduce bugs, especially false confidence from incomplete checks or missed transition paths. — DONE: expanded `docs/demo-dataset-workflow.md` with a targeted selection/panel transition smoke section covering clear-selection, same-cell reselection, bulk → full-records open, and full-records close back to entry. Evidence: doc updated in `/home/montblanc/repos/griddle/docs/demo-dataset-workflow.md` on 2026-04-22; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Bug review: initially attempted to codify an app-level smoke test, but the repo lacks `@testing-library/react` / `@testing-library/user-event`; removed that draft to avoid a false signal and kept the change honest by strengthening the manual regression checklist instead.
- [x] #nextaction Refactor the remaining `src/App.tsx` interaction handling so panel/selection transition decisions are centralized behind a reducer-backed controller or a second-pass transition helper once the first helper layer is stable. Review any changes for anything that might introduce bugs, especially keyboard navigation regressions, stale selection context after dataset changes, and pointer gesture race conditions. — DONE: added a second-pass transition helper layer in `src/App.tsx` (`transitionToNoPanel`, `transitionToEntry`, `transitionToBulk`, `transitionToFullRecords`) and routed the main pointer-release, panel-close, filter/layout reset, orphan-open, and full-records done flows through it instead of scattering ad hoc `setPanelMode` / selection resets. Evidence: local diff in `/home/montblanc/repos/griddle/src/App.tsx` on 2026-04-22; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Bug review: kept keyboard navigation logic untouched; preserved pointer-down defer behavior for grid drags; cleared persisted bulk/full-records ids on transition boundaries to reduce stale selection context after filter/layout changes and orphan/full-records handoffs.
- [x] #nextaction Break up `src/components/FullRecordsPanel.tsx` into smaller pieces (header, table/body, draft/new-record handling, working-set behavior) and remove duplicated record mutation logic in favor of shared domain helpers. Review any changes for anything that might introduce bugs, especially edit persistence, draft row behavior, delete flows, working-set toggles, and selection continuity when moving between full-records and entry. — DONE: split `FullRecordsPanel` into focused internal pieces (`FullRecordsHeader`, `NewDraftRow`, `FullRecordRow`, `CellEditor`) and moved shared record mutation/draft helpers into `src/domain/records.ts`; also completed the related `src/App.tsx` transition-helper cleanup and updated the regression workflow doc. Evidence: commit `119c107` (`Refactor full records panel and selection transitions`), pushed to `origin/master`; validation: `npm test` and `npm run build` passed on 2026-04-22. Bug review: checked edit persistence, draft add/cancel flow, delete-all/delete-single paths, working-set toggle/shift-range behavior, and full-records → entry return path through the updated transition helpers.
- [x] #nextaction Add a shared regression checklist based on `docs/demo-dataset-workflow.md` for the known hotspot flows: single-cell → entry, range select → bulk, full-records open/close, same-cell reselection, toolbar/modal interactions while a panel is open, and any future click-off behavior. Review any changes for anything that might introduce bugs, especially missing smoke coverage for recent fixes or assumptions that leave old regressions untested. — DONE: added a compact shared regression checklist section to `docs/demo-dataset-workflow.md` covering the hotspot interaction flows in one reusable place. Evidence: commit `5215796`; validation passed on 2026-04-22 via `npm run lint`, `npm test`, and `npm run build`. Bug review: doc-only change; checked that the checklist aligns with the existing transition smoke section and does not imply unsupported behavior beyond the current interaction model.
- [x] #nextaction Side-panel UX prep, slice 1: write a short repo note (or expand an existing doc) that defines the exact containment boundaries for future click-off behavior: what counts as the workspace, what counts as top chrome, which modal surfaces must be ignored, and why full-records interactions are explicitly out of scope for click-off deselect. Keep this doc-only and reversible. Review any changes for anything that might introduce bugs, especially documenting behavior that the app does not actually support yet. — DONE: expanded `docs/workspace-interaction-model.md` with a doc-only click-off containment section defining workspace vs top-chrome boundaries, modal surfaces to ignore, and why Full Records stays out of scope for generic click-off deselect. Evidence: commit `94bcc3f`; validation passed on 2026-04-22 via `npm run lint`, `npm test`, and `npm run build`. Bug review: wording stays explicitly future-facing and reversible, and avoids claiming any current click-off behavior that the app does not yet implement.
- [x] #nextaction Side-panel UX prep, slice 2: audit the current side-panel/body markup and CSS for the smallest safe fixed-header + scrollable-body extraction point, then capture a tiny implementation plan in the repo doc with named components/containers to touch and a rollback path. Do not change runtime behavior yet; this slice should be inspection + plan only. Review any changes for anything that might introduce bugs, especially incorrect assumptions about panel DOM ownership, scroll containers, or modal layering. — DONE: added a side-panel UX prep audit/plan section to `docs/workspace-interaction-model.md` covering current Entry/Bulk/Full Records container ownership, the smallest safe header/body extraction points, rollout order, rollback path, and implementation risks to re-check. Evidence: repo doc updated on 2026-04-22 at `/home/montblanc/repos/griddle/docs/workspace-interaction-model.md`; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Bug review: doc-only change; explicitly kept Full Records excluded from drawer click-off experiments and called out drawer height/overflow and modal-layer ownership as assumptions to verify before any runtime refactor.
- [x] #nextaction Side-panel UX prep, slice 3: implement only the fixed-header / scrollable-body polish for one panel path using the plan from slice 2, without adding click-off deselect. Keep the change narrowly scoped to layout/styling so it is easy to revert. Review any changes for anything that might introduce bugs, especially header overlap, scroll trapping, modal interference, and full-records containment issues. — DONE: polished the Entry panel only by splitting `src/components/EntryPanel.tsx` into explicit `panelHeader` + `panelBody` regions and updating `src/components/entryPanel.module.css` so the panel uses a bounded two-row layout with an inner scrollable body. No click-off logic, drawer-shell changes, or Full Records changes were added. Evidence: commit `6e76284` (`Polish entry panel fixed header layout`), pushed to `origin/master`; validation: `npm run lint`, `npm test`, and `npm run build` all passed on 2026-04-22. Bug review: scoped to Entry panel markup/CSS only; preserved existing button actions and tape table behavior, relied on the existing drawer height ownership, and avoided touching modal layering or full-records containment.
- [x] #nextaction Side-panel UX prep, slice 4: add a short manual regression addendum to `docs/demo-dataset-workflow.md` covering the polished panel path (header stays visible while body scrolls, toolbar/modal interactions still work, no unintended deselect behavior). Keep this doc-only and tied to the exact implemented slice. — DONE: added an Entry-panel-specific manual regression addendum to `docs/demo-dataset-workflow.md` covering fixed-header visibility, inner body scrolling, toolbar/modal interaction continuity, and the absence of unintended deselect behavior. Evidence: commit `5c60284`; validation passed on 2026-04-22 via `npm run lint`, `npm test`, and `npm run build`. Bug review: doc-only change; kept it explicitly scoped to the currently implemented Entry panel polish slice and did not imply Bulk or Full Records parity.
- [x] #nextaction Validation UX prep, slice 1: write a concrete validation state-model note in repo docs that defines issue shape, severity levels, stable ids, field/path targeting, and the distinction between record-local issues vs dataset/global issues. Keep it principled and implementation-oriented, but doc-only. Review any changes for anything that might introduce bugs, especially assuming issue-routing behavior the UI cannot yet support. — DONE: added `docs/validation-state-model.md` defining a concrete `ValidationIssue` contract, severity/scope semantics, structured targets with canonical path conventions, stable id rules, and the distinction between record-local vs dataset/global issues. Evidence: repo doc added at `/home/montblanc/repos/griddle/docs/validation-state-model.md` on 2026-04-22; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Bug review: doc-only change; explicitly kept UI routing, navigation prompts, and rendering details out of scope so the contract does not over-promise interaction behavior the app cannot yet support.
- [x] #nextaction Validation UX prep, slice 2: document the issue-targeting rules for the current interaction model: how a validation issue maps to entry, bulk, or full-records surfaces; when navigation should open a panel vs preserve current context; and what should happen when the target field is currently filtered or out of view. Keep this as a bounded design note, not UI code yet. Review any changes for anything that might introduce bugs, especially focus-jump edge cases, stale selection assumptions, or hidden-field mismatches. — DONE: expanded `docs/validation-state-model.md` with a doc-only issue-targeting section defining Entry/Bulk/Full Records/dataset-only routing, preserve-vs-open rules, filtered/out-of-view handling, classification vocabulary, and guardrails against implicit view/filter mutation. Evidence: commit `9c84053` (`Document validation issue targeting rules`), pushed to `origin/master`; validation: `npm run lint`, `npm test`, and `npm run build` all passed on 2026-04-22. Bug review: kept the note aligned with the current interaction model (real `selected` cell for Entry, explicit record-id fallback to Full Records, unresolved for dataset/config issues) and avoided promising auto-view-switching or hidden-target jumps the app cannot yet support.
- [x] #nextaction Validation UX prep, slice 3: add a tiny pure domain helper (or typed stub) for validation issue targeting that can be unit-tested without rendering UI—for example, a function that classifies an issue target as entry-eligible, bulk-only, full-records-only, or unresolved. Keep the helper additive and reversible, with tests if feasible. Review any changes for anything that might introduce bugs, especially overfitting the helper to speculative future UI. — DONE: added pure domain helper `src/domain/validationTargeting.ts` plus `src/domain/validationTargeting.test.ts` to classify validation issue targets into entry/bulk/full-records/dataset-only/unresolved using conservative caller-provided facts instead of UI rendering assumptions. Evidence: validation passed on 2026-04-22 via `npm run lint`, `npm test`, and `npm run build`. Bug review: kept the helper additive and narrow; it does not inspect UI state or auto-infer speculative navigation, so risk is mainly future misuse/overreach rather than runtime behavior change.
- [x] #nextaction Validation UX prep, slice 4: expand `docs/demo-dataset-workflow.md` with a compact validation navigation smoke section based only on the finalized state/targeting rules from slices 1–3. Keep it manual-regression oriented and avoid pretending the full validation UI exists before it does. — DONE: replaced the speculative validation UI quick-check with a compact manual validation navigation smoke section in `docs/demo-dataset-workflow.md` covering dataset-only routing, entry-eligible unique-cell cases, full-records fallback for ambiguous/hidden targets, explicit bulk-only classification, and preserve-current-context behavior. Evidence: repo doc updated at `/home/montblanc/repos/griddle/docs/demo-dataset-workflow.md` on 2026-04-22; validation: `npm run lint`, `npm test`, and `npm run build` all passed. Bug review: doc-only change; kept the checklist aligned with the finalized slices 1–3 contract/helper and explicitly avoided implying a finished validation panel, inline highlighting, or automatic jump UI that does not exist yet.
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
