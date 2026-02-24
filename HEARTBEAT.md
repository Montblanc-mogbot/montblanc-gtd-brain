# HEARTBEAT.md

# Lightweight hygiene checks (keep quiet unless action needed)

## On EVERY heartbeat wake (STRICT — don’t skip steps):
1. Run the picker script to determine the single next actionable todo (the top unchecked todo, skipping `#waitingfor`):
   - `scripts/heartbeat_pick_next.py`
   It returns one line:
   - `INBOX\t<path>\t<line#>\t<todo>` OR `PROJECT\t<path>\t<line#>\t<todo>` OR `NONE...`
2. If it returns `INBOX` or `PROJECT`: **EXECUTE that exact todo** (don’t just report, DO).
3. If it returns `NONE`:
   - post to `#automation-log`: **"No actionable todos found (Inbox + Projects empty); staying idle"**
   - then reply `HEARTBEAT_OK`
4. **Always** post to `#automation-log` once per heartbeat with one of:
   - “Working on: <project> — <exact todo line>”
   - OR the “No actionable todos…” idle message above.
5. **Scope guardrail:** Only work on items that are explicitly represented as todos in `Inbox/inbox.md` or `Projects/*/project.md`.
6. When a todo is completed: **check it off in the source file** (`Inbox/inbox.md` or the relevant `Projects/*/project.md`) and add a short “done + evidence” note (commit hash / file path / link).
7. While working: if I notice any work that isn’t represented by a todo, **stop and capture it** into Inbox (or the relevant project hub) before continuing.
8. Only reply `HEARTBEAT_OK` if truly nothing to do (and only after posting the idle message).

## Periodic checks (when specific conditions met):
- Check for new messages in active `#work` threads since last check; reply in-thread if something needs a response.
- Scan active project hubs (`Projects/*/project.md`) and sanity-check:
  - Each active project has at least one clear `#nextaction`.
  - Any new work being discussed in threads has a captured todo (Inbox or the project hub).
- Scan for open `#waitingfor` items (things that require Matt input) in:
  - `Inbox/waiting-for.md`
  - and `Projects/*/project.md`
  If anything is waiting on Matt:
  - Post a concise “Action needed from Matt” list in `#waiting-for` (link to file + the exact todo lines).
  - Also sanity-check for “already satisfied” items. If satisfied: immediately check it off/remove it and add a short “done + evidence” note.
- If it's Friday morning and weekly review isn't started, post a reminder in `#weekly-review` with the GitHub link.
- If any scheduled job posts an error (e.g., GitHub sync), surface it in `#automation-log`.

## Daily (on first heartbeat of day):
- Create memory/YYYY-MM-DD.md if it doesn't exist
- Review yesterday's memory file for any uncaptured todos
