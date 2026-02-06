# GTD System (how this workspace works)

This is the durable “brain” for the assistant.

## Canonical locations
- **Inbox:** `Inbox/inbox.md`
- **Projects:** `Projects/<project-slug>/project.md`
- **Weekly reviews:** `Reference/weekly-reviews/YYYYMMDD-weekly-review.md`
- **Templates:** `Templates/`
- **Dashboard:** `Reference/dashboards/GTD-dashboard.md`

## Rules
1) **Inbox stays small.** Inbox should contain only genuinely open tasks.
2) **Weekly review is the engine.** Weekly checklists live in the weekly review doc; Inbox may contain a single task pointing to the current week’s review.
3) **Every active project must have at least one `#nextaction`.**
4) **Use tags consistently:**
   - `#nextaction` = next physical action
   - `#waitingfor` = blocked on Matt/external input
   - `#someday` = not active
   - `#focus` = chosen during weekly review
   - `#project/<slug>` = ties tasks to a project
5) **Close the loop every Friday morning.** During weekly review:
   - copy completed work into “Completed Items”
   - delete checked-off items from Inbox
   - pick 3 focused actions for the week
6) **Keep durable context updated.** Each weekly review includes “Maintenance (meta)” tasks to update SOUL/HEARTBEAT/USER/memory.

## How the assistant operates
- Day-to-day: add tasks to Inbox or to a project hub; execute `#nextaction` items.
- Weekly: run/complete the weekly review checklist; generate/adjust recurring tasks inside the weekly review doc; keep Inbox clean.
- Backups: `./sync-gtd.sh` pushes changes to GitHub; a cron job runs it every 30 minutes.

## Obsidian usage
Open `/home/montblanc/.openclaw/workspace/` as a vault. Use global search for tags like `#nextaction` and `#waitingfor`.
