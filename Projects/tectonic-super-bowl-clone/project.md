# Project: Tecmo Super Bowl (NES) → MonoGame remake

## Goal
Use the Tecmo Super Bowl (NES) disassembly as a reference/basis to recreate the classic game in MonoGame.

## Notes / context
- Source thread: Discord #work › Tectonic super bowl
- Reference repo: https://github.com/bruddog/Tecmo_Super_Bowl_NES_Disassembly
- Local clone: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`

## Success criteria
- [ ] MonoGame project boots and renders *something* (window + basic loop)
- [ ] Asset extraction/import pipeline defined (graphics + palettes + tiles)
- [ ] One playable slice (e.g., kickoff or a single down) running end-to-end

## Next actions
- [x] #nextaction Clone reference repo locally (done: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`)
- [ ] #nextaction Reverse-engineer reference repo into a design document (file-by-file + subsystem mapping) suitable for MonoGame remake.
- [ ] #nextaction Confirm scope for MVP (exhibition only? playbook? season mode?) and target platforms.
- [ ] #nextaction Create new MonoGame repo (separate from disassembly) + initial scaffold.
- [ ] #nextaction Identify data/asset formats we need first (CHR/tile sets, palettes, playbook, rosters) and document.

## Backlog
- [ ] Build tooling: script to extract assets from ROM into friendly formats
- [ ] Input mapping + controller support
- [ ] Sound/music plan
- [ ] Save data / season simulation
