#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"

TZ="America/New_York"
# YYYYMMDD for today (or provide as arg)
DATE=${1:-$(TZ="$TZ" date +%Y%m%d)}
ISO=${2:-$(TZ="$TZ" date +%F)}

OUT="Reference/weekly-reviews/${DATE}-weekly-review.md"

mkdir -p Reference/weekly-reviews

if [ ! -f "$OUT" ]; then
  cp Templates/weekly-checklist-template.md "$OUT"
  # update title line if present
  sed -i "s/Weekly Review — YYYYMMDD/Weekly Review — ${DATE}/" "$OUT" || true
fi

# Ensure inbox contains a single open task pointing to this weekly review.
INBOX="Inbox/inbox.md"
mkdir -p Inbox
if [ ! -f "$INBOX" ]; then
  cat > "$INBOX" <<'MD'
# Inbox

> Capture new tasks here. Keep it as a single list of checkbox items.

## Tasks
MD
fi

TASK="- [ ] #nextaction Weekly review (${DATE}) → Reference/weekly-reviews/${DATE}-weekly-review.md"

# Add task if not already present
if ! grep -Fq "Reference/weekly-reviews/${DATE}-weekly-review.md" "$INBOX"; then
  # insert after "## Tasks" line
  awk -v task="$TASK" '
    BEGIN{added=0}
    {print}
    $0=="## Tasks" && added==0 {print task; added=1}
  ' "$INBOX" > "$INBOX.tmp" && mv "$INBOX.tmp" "$INBOX"
fi

echo "$OUT"
