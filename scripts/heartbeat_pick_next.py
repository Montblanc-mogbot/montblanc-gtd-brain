#!/usr/bin/env python3
"""Pick the next actionable todo from Inbox + Projects.

Rules (simple + deterministic):
- Prefer the first unchecked todo line in Inbox/inbox.md (top-to-bottom).
- If none, scan Projects/<project>/project.md in alphabetical project folder order.
- In Projects, pick the first unchecked todo line.
- Always SKIP any todo line tagged `#waitingfor`.

A "todo line" is any line that starts with:
  - [ ]

Outputs a single line:
  <kind>\t<path>\t<line_number>\t<todo_line>
Where kind is INBOX or PROJECT, or NONE if nothing found.
"""

from __future__ import annotations

from pathlib import Path
import re

WORKSPACE = Path(__file__).resolve().parents[1]
INBOX = WORKSPACE / "Inbox" / "inbox.md"
PROJECTS_DIR = WORKSPACE / "Projects"

TODO_RE = re.compile(r"^\s*- \[ \]\s+.*$")


def first_todo_in_file(path: Path) -> tuple[int, str] | None:
    if not path.exists():
        return None
    lines = path.read_text(encoding="utf-8", errors="replace").splitlines()
    for i, line in enumerate(lines, start=1):
        if not TODO_RE.match(line):
            continue
        if "#waitingfor" in line:
            continue
        return (i, line.rstrip("\n"))
    return None


def main() -> int:
    hit = first_todo_in_file(INBOX)
    if hit:
        ln, line = hit
        print(f"INBOX\t{INBOX}\t{ln}\t{line}")
        return 0

    if PROJECTS_DIR.exists():
        for project_dir in sorted([p for p in PROJECTS_DIR.iterdir() if p.is_dir()]):
            project_md = project_dir / "project.md"
            hit = first_todo_in_file(project_md)
            if hit:
                ln, line = hit
                print(f"PROJECT\t{project_md}\t{ln}\t{line}")
                return 0

    print("NONE\t-\t-\tNo actionable todos found")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
