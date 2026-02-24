# Moghome (Discord) — Design doc (draft)

## Goals
- Make Discord the *operational surface* for us: quick capture, decisions, coordination.
- Keep it minimal: few channels, clear purpose, low noise.
- Ensure anything durable ends up in the GTD brain repo (Obsidian vault) when appropriate.

## Non-goals
- Replacing Obsidian as the long-term knowledge base.
- Complex automation/bots beyond what OpenClaw already provides.

## Principles
1) **One channel = one job.** Each channel has an explicit purpose.
2) **Pinned instructions.** Every operational channel gets a short pinned “how to use this channel.”
3) **Low ceremony capture.** You can dump items quickly; we’ll triage during weekly review.
4) **Durable vs ephemeral.** Durable plans live in the workspace repo; Discord is for coordination.

## Proposed structure (minimal)
### Category: GTD
- `#inbox` — quick capture messages; I convert them into `Inbox/inbox.md` tasks.
- `#weekly-review` — weekly review reminders + short summaries; link to weekly review doc in GitHub.
- `#waiting-for` — when something is blocked on Matt; I post concise unblock requests here.

### Category: Work (project-first)
- `#work` — project-focused discussion; use threads per project/task.
- (optional later) `#accounting` and `#programming` if `#work` becomes too busy.

### Category: Ops
- `#automation-log` — only errors/alerts from scheduled jobs (sync failures, cron issues).
- `#decisions` — lightweight decision log (also gets copied to Reference as needed).

### Category: Lounge (optional)
- `#general` — keep as human chat / quick pings.

## Naming conventions
- Lowercase, hyphenated channel names.
- Use short category names.

## Pins (draft)
### `#inbox` pin
- “Drop tasks for Montblanc here (capture-only). I’ll convert them into durable todos in `Inbox/inbox.md`.
- Tip: prefix with `TODO:`.
- I’ll avoid duplicates by checking if it’s already captured or already done.”

### `#weekly-review` pin
- “Fridays AM: weekly review. Source of truth: `Reference/weekly-reviews/` in GitHub repo.”

### `#waiting-for` pin
- “If I’m blocked, I’ll post: what’s blocked + what I need from you + deadline (if any).”

## Open questions for Matt
1) Do you want `#general` to remain the main chat, or do you prefer a dedicated `#ops-chat`?
2) Do you want `#inbox` to be message-only capture (no discussion), with discussion happening in `#general`?
3) Any other recurring work areas besides Accounting + Programming (e.g., “personal admin”, “home”) that deserve a channel?
4) Should `#automation-log` be noisy (all sync confirmations) or quiet (errors only)? (I recommend errors only.)
