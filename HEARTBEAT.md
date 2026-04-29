# HEARTBEAT.md

# Quiet, predictable maintenance first

## On EVERY heartbeat wake (STRICT — don’t skip steps):
1. Run the picker script to determine the single next actionable todo (the top unchecked todo, skipping `#waitingfor`).
   **Priority:** Always prefer Tecmo/Tectonic project hub actions first.
   - `scripts/heartbeat_pick_next_tectonic_first.py`
   It returns one line:
   - `INBOX\t<path>\t<line#>\t<todo>` OR `PROJECT\t<path>\t<line#>\t<todo>` OR `NONE...`
2. If it returns `INBOX` or `PROJECT`:
   - First ask: is this todo **clearly scoped, local, reversible, and non-destructive**?
   - Default stance: if the task is a bounded local doc/code/test/update step in a known repo or workspace file, treat it as eligible for automatic execution unless it requires external credentials, irreversible deletion, deployment/release, or broad ambiguous product judgment.
   - **Bias toward doing the work, not just reporting it.** If the task is a bounded local doc/code/test/update step that can be completed safely in one session, execute it end-to-end instead of replying with a block message.
   - Before doing anything else, classify the todo in one short internal sentence as one of:
     - `SAFE_LOCAL_EXECUTION`
     - `NEEDS_MATT_INPUT`
     - `TOO_RISKY_FOR_HEARTBEAT`
     - `MISSING_CONTEXT`
   - For safe coding/doc tasks, prefer this execution pattern:
     - inspect the relevant files
     - make the smallest clean change that completes the todo
     - run the relevant validation commands
     - if validation passes, commit the change in the project repo with a focused commit message so it is easy to revert (`git revert <hash>`) if bugs appear later
     - push when a remote exists and pushing is part of the normal repo workflow
     - **never** publish/deploy a site, GitHub Pages build, release artifact, or similarly user-facing release output unless the source todo or project hub explicitly says Matt already approved that release step
     - when a project hub includes an approval gate for deployment/release, heartbeat may continue normal source work up to that gate but must stop short of release and leave a clear note for Matt
     - update the source todo with a short DONE note + evidence
   - If it requires external action, credentials, irreversible deletion, deployment/release approval, risky repo surgery, or broad ambiguous product judgment, do **not** execute it blindly. Instead:
     - log the exact todo to `#automation-log`
     - capture any clarification needed in the source of truth
     - leave the todo open
   - **Do not return `HEARTBEAT_OK` or allow an `ok-empty` result when an actionable todo exists.** If you choose not to act, you must reply with a concrete reason in this format:
     - `Heartbeat did not act: <classification> — <exact todo line> — <one-sentence reason>`
   - If a tool failure, missing file, permissions issue, or missing metadata prevents execution, reply with that concrete reason instead of idling.
3. If it returns `NONE`:
   - Do lightweight maintenance only:
     - sanity-check Inbox/project structure
     - review whether any obvious `#waitingfor` item is already satisfied
     - avoid project-pulse posting unless there is a genuinely useful status update to send
   - If there is truly nothing useful and low-risk to do:
     - post to `#automation-log`: **"No actionable todos found (Inbox + Projects empty or blocked); staying idle"**
     - then reply `HEARTBEAT_OK`
4. **Only post to `#automation-log` when meaningful**:
   - “Working on: <project> — <exact todo line>”
   - OR “Completed: <project> — <exact todo line>”
   - OR “Blocked / needs Matt: <exact todo line>”
   - OR the idle message above
   Avoid routine spam when nothing changed.
5. **Scope guardrail:** Only work on items explicitly represented as todos in `Inbox/inbox.md` or `Projects/*/project.md`.
6. When a todo is completed: **check it off in the source file** and add a short “done + evidence” note (commit hash / file path / link).
7. While working: if I notice any work that isn’t represented by a todo, **stop and capture it** into Inbox (or the relevant project hub) before continuing.
8. Only reply `HEARTBEAT_OK` if truly nothing needs attention and there is no actionable todo available from the picker.

## Periodic checks (lightweight, not mandatory every cycle)
- Check active `#work` threads only when there is reason to believe something changed or needs a reply.
- When reviewing active project threads, distill meaningful updates into the relevant project hub instead of leaving the thread as the only source of truth.
  - Capture decisions, clarified requirements, blockers, bug reports, accepted/rejected approaches, and new todos.
  - Append concise bullets to the project hub’s `Thread digest` section.
  - Update that hub’s `last_thread_digest_at` marker.
  - Avoid duplicate digestion when nothing meaningful changed.
- Scan active project hubs (`Projects/*/project.md`) and sanity-check:
  - each active project has at least one clear `#nextaction`
  - project-specific todos live in the project hub, not Inbox
  - new work discussed elsewhere has been captured in the correct project hub
- Scan for open `#waitingfor` items in:
  - `Inbox/waiting-for.md`
  - `Projects/*/project.md`
  If something is waiting on Matt **and a reminder would be genuinely useful**, post a concise “Action needed from Matt” summary in `#waiting-for`.
- If it is Friday morning and the weekly review has not started, send a reminder in `#weekly-review`.
- If any scheduled job posts an error (for example, GitHub sync), surface it in `#automation-log`.

## Daily (on first heartbeat of day)
- Create `memory/YYYY-MM-DD.md` if it does not exist.
- Review yesterday’s memory file for uncaptured todos or durable lessons.
- If a daily memory note contains durable preferences/rules/lessons, promote those into the right long-term home:
  - `MEMORY.md` for durable cross-project truths
  - `Projects/<slug>/project.md` for project-specific memory
  - `AGENTS.md` / `TOOLS.md` / `SOUL.md` for operating rules
- Glance at `~/transfer/` as a staging area only when there is reason to expect inbound files; if new files appear, triage them into the correct project/reference location rather than leaving them there indefinitely.

## Memory boundary rule
- `memory/YYYY-MM-DD.md` = episodic daily log
- `Projects/*/project.md` = canonical project memory and default home for project todos
- `MEMORY.md` = durable cross-session truths only
- project-thread messages should be distilled into project hubs regularly, not mirrored wholesale
- Heartbeats should prefer maintaining these boundaries over generating extra chatter
