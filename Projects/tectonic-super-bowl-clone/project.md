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
- [ ] #nextaction Phase 1: Rendering pipeline

## Backlog
- [ ] Build tooling: script to extract assets from ROM into friendly formats
- [ ] Input mapping + controller support
- [ ] Sound/music plan
- [ ] Save data / season simulation
