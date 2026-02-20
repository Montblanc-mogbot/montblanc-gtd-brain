# HEARTBEAT.md

# Lightweight hygiene checks (keep quiet unless action needed)

## On EVERY heartbeat wake:
1. Read Inbox/inbox.md - are there open #nextaction items?
2. If yes: EXECUTE the highest priority one immediately (don't just report, DO)
3. Post status to #automation-log showing what you're working on
4. Only reply HEARTBEAT_OK if truly nothing to do

## Periodic checks (when specific conditions met):
- Check for new messages in active `#work` threads since last check; reply in-thread if something needs a response.
- Scan `Inbox/inbox.md` for open `#waitingfor`:
  - If anything is waiting on Matt, post a concise unblock request in `#waiting-for`.
  - Also sanity-check for “already satisfied” items (e.g., file now present, data already ingested, access granted). If satisfied: immediately mark done/remove from Inbox and add a short “done + evidence” note (path/commit/link).
- If it's Friday morning and weekly review isn't started, post a reminder in `#weekly-review` with the GitHub link.
- If any scheduled job posts an error (e.g., GitHub sync), surface it in `#automation-log`.

## Daily (on first heartbeat of day):
- Create memory/YYYY-MM-DD.md if it doesn't exist
- Review yesterday's memory file for any uncaptured todos
