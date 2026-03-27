# MEMORY.md - Long-term Knowledge

## About Matt
- Name: Matt (squadronhawk)
- Timezone: America/New_York
- Work: Programming projects + accounting

## How Matt likes me to work
- Wants to see what I’m doing in real-time
- Everything must have a todo before doing it
- Commits must be pushed and logged
- Uses a GTD system for task management
- Wants predictable organization: the Obsidian vault is for GTD, notes, memory, and project context; code belongs in repos

## System Setup
- OS: Fedora 43 Workstation (GNOME)
- OpenClaw workspace / Obsidian vault: `/home/montblanc/.openclaw/workspace`
- GTD brain repo: `github.com/Montblanc-mogbot/montblanc-gtd-brain`
- Local repos directory: `/home/montblanc/repos/`
- Shared transfer/staging directory on this machine: `~/transfer/`

## Canonical organization rules
- Inbox: `Inbox/inbox.md`
- Waiting-for list: `Inbox/waiting-for.md`
- Project hubs: `Projects/*/project.md`
- Weekly reviews: `Reference/weekly-reviews/`
- Daily episodic memory: `memory/YYYY-MM-DD.md`
- Long-term memory: `MEMORY.md`
- Project hubs are the canonical memory for project-specific context
- `MEMORY.md` is only for durable cross-project truths, not transient project status
- Code should live in `/home/montblanc/repos/<project>` and generally be synced to private GitHub repos

## Durable project facts
- Griddle repo: `github.com/Montblanc-mogbot/griddle` (local: `/home/montblanc/repos/griddle`)
- TBH Report Catalog repo: `github.com/Montblanc-mogbot/tbh-report-catalog` (local: `/home/montblanc/repos/tbh-report-catalog`)
- Tecmo Super Bowl remake repo lives under `/home/montblanc/repos/tecmo-super-bowl-monogame`

## Key Decisions
- Model family: Codex-only
- GitHub sync cadence: every 30 minutes via cron
- Weekly reviews: Friday mornings
- Status updates go to `#automation-log`

## Important Rules
- Never accept passwords in chat
- All work gets a todo first
- Check off todos as completed
- Push to GitHub after each commit
- Keep project state in project hubs and durable truths in `MEMORY.md`

## Lessons learned
- Do not claim a subagent was spawned unless `sessions_spawn` actually returned a real session/result
- Avoid duplicate or stale workspace directories; keep one canonical workspace and archive stray copies instead of deleting first
