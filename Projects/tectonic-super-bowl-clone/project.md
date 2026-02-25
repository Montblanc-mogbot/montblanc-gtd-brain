# Project: Tecmo Super Bowl (NES) → MonoGame remake

## Goal
Use the Tecmo Super Bowl (NES) disassembly as a reference/basis to recreate the classic game in MonoGame.

## Notes / context
- Source thread: Discord #work › Tectonic super bowl
- Reference repo: https://github.com/bruddog/Tecmo_Super_Bowl_NES_Disassembly
- Local clone: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`

## Success criteria
- [x] MonoGame project boots and renders *something* (window + basic loop) — DONE: added src/TecmoSBGame (MonoGame DesktopGL) that boots and clears screen. Commit: a220090
- [x] Asset extraction/import pipeline defined (graphics + palettes + tiles) — DONE: Created docs/ASSET_PIPELINE.md, tools/extract_chr.py, tools/convert_chr_to_png.py, Content/Content.mgcb. Commit: a46994f (local; push blocked—no git remote configured).
- [x] One playable slice (e.g., kickoff or a single down) running end-to-end — DONE: Implemented kickoff scenario with InputSystem (keyboard/controller), GameStateSystem (5 phases: setup→flight→return→tackle→end), player spawning, AI coverage/return behavior, tackle detection. Commit: f3e1eee (local; push blocked—no git remote configured).

## Next actions
- [x] #nextaction Clone reference repo locally (done: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`)
- [x] #nextaction Reverse-engineer reference repo into a design document (file-by-file + subsystem mapping) suitable for MonoGame remake. — DONE: All banks scaffolded, DESIGN.md created. Repo: https://github.com/Montblanc-mogbot/tecmo-super-bowl-monogame
- [x] #nextaction Ask Matt clarifying questions — ANSWERED 2025-02-24
  - Project structure: Keep split (cleaner) ✓
  - Content loading: Load at startup ✓
  - MonoGame version: Latest stable ✓
  - IDE: VS Code (pure code) ✓
  - ECS scope: Use MonoGame.Extended.Entities for future extensibility (roguelike season mode, character progression, special abilities)
- [x] #nextaction Phase 1: Project setup — DONE: MonoGame project structure created, solution configured, builds successfully. Commit: a220090, 67f27d3
- [x] #nextaction Phase 1: Content pipeline (YAML loading) — DONE: GameContent loads all YAML at startup. Builds successfully. Commit: f9018ba
- [x] #nextaction Phase 1: Basic entity system — Using MonoGame.Extended.Entities — DONE: Components and Systems created, ECS integrated. Commit: 17a3b46
- [x] #nextaction Phase 1: Rendering pipeline — DONE: Added RenderViewport (NES 256x224 scaling), FieldRenderer (field, yard lines, end zones), integrated with ECS RenderingSystem. Commit: eacd37c (local; push blocked—no git remote configured).

## Phase 2: On-Field Gameplay #nextaction

### Player Entity Factory
- [ ] #nextaction Create PlayerEntityFactory — Map team roster data to ECS entities
  - Convert RS rating to MaxSpeed (3.0-6.5 pixels/frame)
  - Attach PlayerAttributesComponent with all ratings (HP, RS, MS, RP, BC, REC, PA, AR, KP, KA)
  - Attach Position, Velocity, Sprite, Team components
  - Create 11 offensive + 11 defensive entities per team

### Formation Positioning
- [ ] #nextaction Implement FormationPositioningSystem — Place players at snap
  - Load formation from YAML (content/formations/formation_data.yaml)
  - Map formation slots (QB, RB1, RB2, WR1, WR2, etc.) to roster positions
  - Set initial PositionComponent based on yard line and formation coordinates
  - Handle flipping formations for left/right hash

### Play Execution
- [ ] #nextaction Create BehaviorFactory — Convert YAML play commands to behaviors
  - Parse pullRelative, pullAbsolute, wait, block, rushQB commands
  - Create RushQBBehavior (move toward QB, grapple blockers, tackle)
  - Create RouteBehavior (follow waypoints, track depth)
  - Create BlockBehavior (engage defender, grapple)
  - Create ManCoverageBehavior (track assigned receiver)
  - Create ZoneDropBehavior (go to zone, read ball)

### Input Handling
- [ ] #nextaction Implement InputSystem — User control of selected player
  - Keyboard: Arrow keys/WASD for movement, Space/A for action (dive/tackle/switch player)
  - Gamepad: Left stick for movement, A for action, B for speed burst
  - Cycle through players with LB/RB or Tab
  - Auto-select ball carrier on offense, closest defender on defense

### Collision Detection
- [ ] #nextaction Create CollisionSystem — Discrete frame-by-frame checks
  - Check distance between all offensive/defensive players (~8px collision range)
  - Trigger GrappleBehavior when defender meets blocker (HP vs HP check)
  - Trigger TackleAttempt when defender reaches ball carrier
  - Handle pass defense (defender near receiver when ball arrives)

### Game State Management
- [ ] #nextaction Implement GameStateSystem — Track down, distance, possession
  - States: PreSnap, Snap, PlayActive, Tackle, OutOfBounds, Touchdown, Turnover
  - Track down (1-4), yards to go, field position, possession
  - Transition states based on play outcome
  - Reset formation after each play

### Play Result Resolution
- [ ] #nextaction Create PlayResultSystem — Determine play outcome
  - Calculate yards gained/lost from ball carrier position
  - Detect touchdowns (cross goal line), safeties (tackled in own end zone)
  - Handle incomplete passes, interceptions, fumbles
  - Update down/distance or reset for new series

---

## Backlog
- [x] Build tooling: script to extract assets from ROM into friendly formats — DONE: Created tools/extract_chr.py, tools/convert_chr_to_png.py, docs/ASSET_PIPELINE.md. Commit: a46994f (local; push blocked—no git remote configured).
- [x] Input mapping + controller support — DONE: InputSystem with keyboard (arrows/WASD/space) and gamepad support. Commit: f3e1eee (local; push blocked—no git remote configured).
- [x] Sound/music plan — DONE: Created docs/SOUND_MUSIC_PLAN.md with audio architecture, implementation strategy, asset pipeline, and volume/priority levels. Commit: 9e7b82a (local; push blocked—no git remote configured).
- [x] Save data / season simulation — DONE: Created docs/SAVE_SEASON_DESIGN.md with save data schema, SeasonManager design, schedule generation, stats tracking, and standings calculation. Commit: 31d9140 (local; push blocked—no git remote configured).
