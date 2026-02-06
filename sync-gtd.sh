#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"

# Pull first in case you edited from work / another machine
if git remote get-url origin >/dev/null 2>&1; then
  git pull --rebase --autostash
fi

# Stage changes (explicit allowlist; avoids committing random files)
git add \
  Inbox \
  Projects \
  Reference/dashboards \
  Reference/weekly-reviews \
  Reference/daily \
  Templates \
  README-OBSIDIAN.md \
  .obsidian/app.json \
  .obsidian/core-plugins.json \
  .gitignore \
  SOUL.md USER.md TOOLS.md IDENTITY.md AGENTS.md \
  || true

# Commit if there are changes
if ! git diff --cached --quiet; then
  git commit -m "Sync GTD brain $(date +%F)"
fi

git push
