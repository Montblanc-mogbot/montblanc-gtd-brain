# Project: Tecmo Super Bowl (NES) → MonoGame remake

## Goal
Use the Tecmo Super Bowl (NES) disassembly as a reference/basis to recreate the classic game in MonoGame.

## Notes / context
- Source thread: Discord #work › Tectonic super bowl
- Reference repo: https://github.com/bruddog/Tecmo_Super_Bowl_NES_Disassembly
- Local clone: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`

## Success criteria
- [x] MonoGame project boots and renders *something* (window + basic loop) — DONE: added src/TecmoSBGame (MonoGame DesktopGL) that boots and clears screen. Commit: a220090
- [ ] Asset extraction/import pipeline defined (graphics + palettes + tiles)
- [ ] One playable slice (e.g., kickoff or a single down) running end-to-end

## Next actions
- [x] #nextaction Clone reference repo locally (done: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`)
- [x] #nextaction Reverse-engineer reference repo into a design document (file-by-file + subsystem mapping) suitable for MonoGame remake. — DONE: All banks scaffolded, DESIGN.md created. Repo: https://github.com/Montblanc-mogbot/tecmo-super-bowl-monogame
- [x] #nextaction Phase 1: Project setup — DONE: MonoGame project structure created, solution configured, builds successfully. Commit: a220090, 67f27d3
- [x] #nextaction Phase 1: Content pipeline (YAML loading) — DONE: YamlContentLoader implemented with caching and error handling. Commit: 12c3a04
- [ ] #nextaction Phase 1: Basic entity system
- [ ] #nextaction Phase 1: Rendering pipeline

## Backlog
- [ ] Build tooling: script to extract assets from ROM into friendly formats
- [ ] Input mapping + controller support
- [ ] Sound/music plan
- [ ] Save data / season simulation
