# Project: Tecmo Super Bowl (NES) → MonoGame remake

## Goal
Use the Tecmo Super Bowl (NES) disassembly as a reference/basis to recreate the classic game in MonoGame.

## Notes / context
- Source thread: Discord #work › Tectonic super bowl
- Reference repo: https://github.com/bruddog/Tecmo_Super_Bowl_NES_Disassembly
- Local clone: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`

## Success criteria
- [x] MonoGame project boots and renders *something* (window + basic loop) — DONE: added src/TecmoSBGame (MonoGame DesktopGL) that boots and clears screen. Commit: a220090 (local; push blocked—no git remote configured).
- [ ] Asset extraction/import pipeline defined (graphics + palettes + tiles)
- [ ] One playable slice (e.g., kickoff or a single down) running end-to-end

## Next actions
- [x] #nextaction Clone reference repo locally (done: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`)
- [x] #nextaction Reverse-engineer reference repo into a design document (file-by-file + subsystem mapping) suitable for MonoGame remake. — DONE: All banks scaffolded, DESIGN.md created. Repo: https://github.com/Montblanc-mogbot/tecmo-super-bowl-monogame
- [ ] #nextaction Review scope and ask Matt clarifying questions for Phase 1 — Confirm project structure, target platforms, content loading strategy, MonoGame version
- [ ] #nextaction Phase 1: Project setup — Create MonoGame project structure, solution, configure YAML pipeline, add YamlDotNet
- [ ] #nextaction Phase 1: Content pipeline (YAML loading) — Implement YamlContentLoader, ContentManager wrapper, test loading existing YAML files
- [ ] #nextaction Phase 1: Basic entity system — Create Entity base class, Component system, Player/Ball entities, BehaviorComponent for AI
- [ ] #nextaction Phase 1: Rendering pipeline — SpriteBatch config, FieldRenderer, PlayerRenderer, camera/viewport, 256x224 base resolution

## Backlog
- [ ] Build tooling: script to extract assets from ROM into friendly formats
- [ ] Input mapping + controller support
- [ ] Sound/music plan
- [ ] Save data / season simulation
