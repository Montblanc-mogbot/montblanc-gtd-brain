# Tecmo Super Bowl Reimplementation (MonoGame)

## TL;DR
Reimplement Tecmo Super Bowl gameplay/systems in C# (MonoGame) with data sourced from YAML rather than NES ROM/RAM assumptions.

## Repo(s)
- Work product: `/home/montblanc/repos/tecmo-super-bowl-monogame`
  - Remote: https://github.com/Montblanc-mogbot/tecmo-super-bowl-monogame
- Reference/disassembly: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`

## Discord thread
- Thread/channel link/id: channel:1475718912904663040  ("Tectonic super bowl")

## Pulse tracking (anti-spam)
- last_pulse_at: 
- last_pulse_message_id: 
- awaiting_matt: false

## Context / where notes live
- Project hub (this file)
- Repo docs: `tecmo-super-bowl-monogame/docs/*`
- GTD inbox for next actions: `Inbox/inbox.md`

## Goals
- Maintain a playable “vertical slice” (2 plays playable, end-to-end loop)
- Keep systems/data modular and YAML-driven

## What done looks like (definition of done)
- Boot to playable game loop
- Playcall → snap → play execution → whistle/end → next play
- Core mechanics stable (handoff, pursuit, tackle/end)
- Headless/smoke scenario to validate critical assertions

## Current status (rolling)
- Last known milestone: “2 plays playable” demo implemented in repo + headless smoke scenario.

## Next actions
<!-- Put concrete #nextaction todos here. If empty, heartbeat is allowed to post a project pulse + suggest next actions, but should not spam. -->

