# Weekly Review — 20260429

## Get Clear
- [x] Close open loops (anything on your mind) into Inbox
- [x] Clear Inbox (goal: Inbox only contains **open** tasks)
  - [x] Move/convert items into Projects as needed
  - [x] Copy checked-off Inbox items into this doc under “Completed Items”
  - [x] Delete checked-off items from Inbox
- [x] Create any new project hubs needed
- [x] Archive any completed projects (move project folder → Reference/finished-projects)

## Generate Weekly Tasks (recurring)
> Create any tasks that should happen every week and put them in Inbox (or directly in a project hub).
- [x] Review the previous weekly review and copy forward any still-relevant recurring tasks
- [x] Add this week’s recurring tasks to Inbox (leave unchecked)
  - [x] Weekly review (20260429) created in Inbox and executed here
  - [x] Carry forward the 3-day heartbeat picker revert reminder in Inbox/waiting-for
  - [x] Leave open project-specific waiting-for items in their canonical lists/project hubs

## Get Current
- [x] Mark done / delete / clarify any todos (scan Inbox + active project hubs)
- [x] Ensure every active project has at least one Next Action
- [x] Review Next Actions
- [x] Review Waiting For
- [ ] Review Someday / Maybe

## Get Focused
- [x] Add a #focus tag to 3 items that are tagged #nextaction
- [x] List those focused actions here:
  - [x] #focus Griddle — Continue all Griddle implementation work on branch `stabilization-pass-1` against the `fork` remote first; only propose upstream merge/promotion after validation on the integration fork.
  - [x] #focus TBH Report Catalog — Audit the existing analytics and reports to enforce the rule that each analytic produces exactly one CSV artifact and each report produces exactly one report artifact.
  - [x] #focus Tectonic Super Bowl — Add the Discord thread id/link for this project to the notes/context section.
- [x] Note whether last week’s focused actions were completed
  - This review is the first active weekly review file after the stale reminder cleanup, so there is no clean prior focus list to evaluate from a canonical weekly-review note.

## Maintenance (meta)
- [x] Review this weekly review and update durable context as needed:
  - [x] SOUL.md (behavior/style rules)
  - [x] HEARTBEAT.md (what to check proactively)
  - [x] USER.md (preferences, ongoing work)
  - [x] MEMORY.md / daily memory files (distill what matters)
- [x] Quick sanity check: GitHub sync job is running and repo reflects changes
  - Evidence: heartbeat-generated GTD work and review files are present; no additional sync failure note surfaced in Inbox/heartbeat context during this review.

## Completed Items
> Paste/copy completed items from Inbox (and/or projects) here as your weekly record.

### From Inbox
- [x] #nextaction Heartbeat/cron hygiene: stop stale weekly-review reminders from firing when the current week has no active weekly review file, and make sure a heartbeat-triggered Griddle task actually executes instead of being preempted by old reminder behavior. — DONE: updated `generate-weekly-review.sh` so each run maintains a single open weekly-review inbox task for the current date and marks older open weekly-review tasks as superseded; also repaired a malformed `Inbox/inbox.md` line where an old weekly-review task had been concatenated onto another completed item. Evidence: generated `Reference/weekly-reviews/20260429-weekly-review.md`, added the current `Weekly review (20260429)` task, and converted stale 20260306 review task state to done/superseded. Validation: `bash -n generate-weekly-review.sh` passed; post-run inbox review shows only one open weekly-review task.
- [x] #nextaction Griddle autonomy: update the Griddle project hub so all future Griddle changes happen in a dedicated fork/branch workflow (not directly on origin/master), and relax HEARTBEAT.md risk rules so bounded local code/doc/test work can execute autonomously instead of defaulting to “too risky”. — DONE: created `Montblanc-mogbot/griddle-integration` as the integration fork remote (`fork`), pushed current Griddle state there, updated Griddle project hub workflow rules, switched heartbeat priority to `scripts/heartbeat_pick_next_griddle_first.py`, and loosened heartbeat automatic-execution criteria for bounded local work.
- [x] #nextaction TecmoSB Arch+Gum refactor: create feature-flagged Arch simulation skeleton + Arch.EventBus event structs + upsert helpers (first migration milestone). — DONE: Arch Sim skeleton + systems/spawners in `src/TecmoSBGame/SimArch/*`, feature flag `--sim=arch`, and event struct(s) under `SimArch/Events/*`; helper patterns via query-based upserts. Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` (latest commit `296af82`).
- [x] #nextaction GTD autonomy: create/refresh project hubs (tecmo reimplementation, data pipeline, monthly reconciliation) with “done looks like”, goals, repo links, and Discord thread mapping; update heartbeat behavior to post project summaries + suggested next actions when a project has no #nextaction, but don’t repeat if last summary is awaiting Matt. — DONE: created project hubs + wired threads (Tecmo/TBH/Material Schedule/Griddle), updated HEARTBEAT.md with project pulse mode + anti-spam, posted first concise pulses to each project thread and saved message ids in hubs.
- [x] #nextaction TecmoSB: fix runtime "build" errors from `dotnet run` (YAML VALIDATION FAILED ~271 issues). Make content validation non-fatal for missing formations/play_numbers OR scope playlist/formation types to the subset of implemented content so the game boots. — DONE: YAML validation now non-fatal by default + filters invalid playlist entries; merged ball components to avoid 32-component ECS limit; `dotnet run` boots (commit 5de12a3)
- [x] #nextaction Weekly review (20260314) → Reference/weekly-reviews/20260314-weekly-review.md — DONE: created/updated weekly review doc and copied completed items (Reference/weekly-reviews/20260314-weekly-review.md)
- [x] #nextaction Tectonic Super Bowl: audit current on-field loop on `main` and write a short checklist of what’s missing for “2 plays playable” (TrackingPlayer + handoff + defender pursuit + whistle/end) with file pointers. — DONE: added docs/2-plays-playable-checklist.md (commit 3593ef0)
- [x] #nextaction Tectonic Super Bowl: triage Matt’s playcall UI + camera issues (playcall selection doesn’t respond to Enter; players still move during playcall; camera too zoomed in) and capture root-cause + fix plan. — DONE: root causes found (autoplaycall flag prevented manual input; PlaySelectedEvent had no consumer; formation defaulted to kickoff "00" with 0 plays; kickoff scripts interfered; missing Content .xnb build caused crash) and implemented short-term plan (scrap playcall UI → placeholder overlay + forced play 10; MGCB build to output Content/*.xnb). Evidence: commits c09b92a, 3333260
- [x] #nextaction Weekly review (20260306) → Reference/weekly-reviews/20260306-weekly-review.md — DONE: superseded by weekly review (20260429) generation.
- [x] #nextaction GTD brain repo: resolve dirty working tree (untracked Reference/tech-notes, src/TecmoSBGame/*, modified MEMORY.md) so sync-gtd.sh reliably commits what it should (either add to allowlist/gitignore, or move to correct repo). — DONE: added Reference/tech-notes + MEMORY.md to sync allowlist; gitignored /src and /.trash; removed stray tracked src/TecmoSBGame files from GTD repo (copy kept in .trash/2026-03-17). Evidence: commit 6646cb6.

