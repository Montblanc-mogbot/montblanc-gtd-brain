# Tecmo Super Bowl (NES) — Reverse-engineered design doc (from bruddog disassembly)

Source repo: https://github.com/bruddog/Tecmo_Super_Bowl_NES_Disassembly  
Local clone: `/home/montblanc/repos/Tecmo_Super_Bowl_NES_Disassembly`

This document is intended to:
1) explain **how the original NES game is structured** (banks, subsystems, data flow), and
2) serve as a **port/remake blueprint** for a MonoGame implementation.

> Note: This is reverse-engineered from a commented 6502/MMC3 disassembly. The repo is very large (tens of thousands of lines). I’m treating “review each file” as: **identify the role of each file, its public entry points/major sections, what data it contains, and how it interacts with the rest of the system**.

---

## 0) How to read this disassembly (and how we can lean on `/DOCS`)

You’re right: the repo’s `/DOCS` folder already contains a lot of “design-level” reverse engineering (ROM map, field layout, playbook guides, etc.). That lets us write a deep remake design without having to do a full instruction-by-instruction analysis.

Practically:
- We use `DOCS/rom_map.xlsx` as the **authoritative top-down module map** (what lives in each bank / ROM range).
- We use text docs like `DOCS/formation.txt`, `DOCS/playlist.txt`, `DOCS/offextra.txt`, `DOCS/defextra.txt` as **human-readable decodes** of the play/formation scripting data.
- We only dip into ASM to answer questions like “what does bytecode opcode FC do?” or “what is the exact player RAM struct layout?”


### Build entrypoint
- `master_build.asm` includes constants, RAM labels, macros, and then includes each bank file.
- It also `.INCBIN`s large chunks of graphics from an original ROM file named `TSB.nes`.

### Bank model
The game targets a typical NES + **MMC3** mapper layout with a set of PRG banks.
- Most `BankXX_*.asm` files correspond to the contents of a PRG bank (or combined banks).
- `Bank31_fixed_bank.asm` is the “fixed” bank (always mapped) and holds reset/NMI/IRQ plus shared engine utilities.

### Code organization markers
The author uses fold markers like:
- `_F{_SECTION_NAME` … `_F}_SECTION_NAME`

These are the best “table of contents” for each large bank.

---

## 1) Repository map (every file/folder)

### 1.1 Key `/DOCS` assets (high leverage)
- `DOCS/rom_map.xlsx` — top-down ROM layout: which features live in which bank/range (this is basically a subsystem index). Example rows show:
  - Team/player names + attributes (Bank 1/2)
  - Formation/play pointers (Bank 3/4)
  - Offensive/defensive play command scripts (Bank 5/6)
  - Cutscene and menu “screen scripts” (Banks 7/8/16)
  - Sprite scripts (Banks 9/10)
  - On-field gameplay logic (Banks 21/22)
  - Draw-script engine (Bank 24)
  - Sound engine + sound data (Banks 28–30)
- `DOCS/formation.txt` — decoded examples of **formation scripts** and player bytecode sequences (very useful to define our own data model for formations/plays).
- `DOCS/playlist.txt` — decoded mapping of play names → slot/category → formation → play # arrays → defensive response IDs.
- `DOCS/offextra.txt` / `DOCS/defextra.txt` — “extra” behavior script snippets by role/position (celebrate, pass rush, blocking assignments, returns, etc.).
- `DOCS/tecmo_yardline_reference.txt` — yardline ↔ internal two-byte encoding reference.
- Spreadsheets like `FIELDLAYOUT.xlsx`, `ppu_helper.xlsx`, `rollanimation.xlsx`, `speedchart_3.xlsx` — all likely encode mechanical/gameplay constants and layout coordinates we can port directly.


### Top-level build + data
- `README.md` — project description, build instructions, pointers to DOCS.
- `master_build.asm` — master include file; defines include order and large `.INCBIN` graphics ranges.
- `asm6.bat` — helper to run ASM6 build on Windows.
- `large_text_tile_data.asm` — small table/data for large font/tiles (referenced by draw routines).

### Primary bank files (game code and game data)
These are included in `master_build.asm` in rough order of “data banks” then “code banks”:
- `Bank1_2_team_data.asm` — team/player names + attributes/rosters and related tables.
- `Bank3_formation_metatile_data.asm` — formation pointer tables + background metatile definitions.
- `Bank4_def_spec_play_pointers_data.asm` — defensive/special play pointer tables.
- `Bank5_6_off_def_play_data.asm` — play/formation scripts (player command scripts) and supporting data.
- `Bank7_scene_scripts.asm` — cutscene scripts.
- `bank8_scene_scripts.asm` — season/static screen scripts.
- `Bank9_sprite_scripts.asm` — metasprite scripts.
- `Bank10_sprite_scripts.asm` — more metasprite/sprite scripts.
- `Bank11_12_BG_metatile_tiles.asm` — background tile/metatile sets and related draw data.

Banks that contain a mix of code + some data:
- `Bank12_13_sim_update_stats.asm` — season simulation + stat update logic.
- `Bank14_pal_fall_player_anim.asm` — palettes + fall/down animations.
- `Bank15_faces_playbooks.asm` — player faces + playbooks and associated UI data.
- `Bank16_menu_screens_slidebar.asm` — menu screens + slidebar/scroll UI pieces.
- `Bank_16_team_data.asm` — smaller “bank 16 team data” adjunct (naming is a bit inconsistent).
- `Bank17_18_main_game_loop.asm` — intro/start, main menus, season/pro-bowl flows, many UI screens.
- `Bank19_20_on_field_gameplay_loop.asm` — on-field state machine: run/pass/kick, turnovers, scoring, possession changes.
- `Bank20_playcall.asm` — play-call screen logic (selection UI, play change).
- `Bank21_22_play_commands_on_field_logic.asm` — player command interpreter + collision/tackle/grapple logic.
- `Bank23_draw_field_ball_ani_coll_check.asm` — field draw helpers + ball animation + collision checks.
- `Bank24_draw_script_engine.asm` — background draw-script bytecode engine + PPU transfer commands.
- `Bank25_leaders_player_data_pro_bowl_abbrev.asm` — leaders screens, player data views, pro-bowl, abbreviations.
- `Bank26_misc.asm` — misc utilities and season helpers.
- `Bank27_misc.asm` — more misc/utility.
- `Bank28_sound_engine.asm` — full sound engine (command interpreter, tables, SFX/song address tables).
- `Bank29_sound_data.asm` — sound/music data.
- `Bank30_sound_data.asm` — more sound/music data.
- `Bank31_fixed_bank.asm` — RESET/NMI/IRQ, task system, PPU buffering, common routines.
- `Bank32_DMC_Samples_reset_vector.asm` — DMC samples + reset vectors (very small).

### Constants & memory labeling (`constants_variables/`)
These files define the shared vocabulary: bank IDs, PPU locations, RAM variables, etc.
- `bank_ids.asm` — numeric IDs used by bank swap macros.
- `banner_ids.asm` — identifiers for banner/task overlays.
- `chr_bank_names.asm` — names/IDs for CHR pages.
- `color_ids.asm` — palette IDs.
- `constants.asm` — general constants.
- `cutscene_sequence_ids.asm` — IDs for sequences.
- `def_starter_sprite_locations.asm` — sprite positions for defensive starter screen.
- `field_locations.asm` — field coordinate/yards references.
- `formation_ids.asm` — formation IDs.
- `menu_choices.asm` — menu ID constants.
- `mmc3_registers.asm` — mapper register definitions.
- `nes_registers.asm` — PPU/APU/IO register addresses.
- `pallete_indexes.asm` — palette index constants.
- `*_ppu_locations.asm` (`ppu_locations.asm`, `coin_toss_ppu_locations.asm`, etc.) — fixed PPU nametable addresses for UI placement.
- `scene_ids.asm` — scene/script IDs.
- `skill_indexes.asm` — player skill indices.
- `sprite_script_ids.asm` — sprite script IDs.
- `sound_ids.asm` — sound effect/music IDs.
- `stat_indexes.asm` — stat indices.
- `team_ids_league_structure.asm` — teams + conferences/divisions.
- `tile_id_constants.asm` — tile IDs.
- `zero_page_variables.asm` — ZP RAM map labels (0x0000–0x00FF).
- `ram_variables.asm` — RAM labels (0x0100–0x07FF).
- `sram_variables.asm` — save RAM labels (0x6000–0x7FFF).

### Macros (`macros/`)
These macro files provide “engine-level” primitives and are crucial for understanding intent.
- `6502_macros.asm` — general 6502 helpers.
- `nes_macros.asm` — PPU/controller helpers.
- `mmc3_macros.asm` — bank swap/mapper macros.
- `joypad_macros.asm` — controller read helpers.
- `math_macros.asm` — arithmetic helpers.
- `memory_save_load_clear_macros.asm` — SRAM/RAM clear/load/save patterns.
- `check_status_macros.asm`, `set_init_status_macros*.asm` — status flag manipulation.
- `play_call_macros.asm`, `play_data_macros.asm`, `player_ram_macros.asm` — play/player structure field access.
- `field_scroll_limit_macros.asm`, `set_compare_player_ball_to_yardlines_macros.asm` — field/yards logic helpers.
- `structure_macros.asm` (and misspelled `struture_macros.asm`) — structure-like helpers.
- `tecmo_macros.asm` — game-specific convenience macros.

### Tooling and docs
- `DOCS/` — spreadsheets, guides, reference images, and format notes.
  - `rom_map.xlsx` is called out in README as a “start here”.
- `TOOLS/asm6f_32.exe` — assembler used to build.
- `TOOLS/TSBIDesign.exe` — ancillary tool (likely for playbook/graphic editing).

---

## 2) High-level game architecture (as implemented on NES)

### 2.1 Execution model: RESET → per-frame NMI, plus IRQ
**Core loop:**
- `RESET` initializes RAM/PPU/APU/mapper state.
- Every frame, `NMI` runs once during VBlank:
  - transfers buffered PPU updates,
  - reads controllers,
  - updates RNG, tasks, timers,
  - schedules or runs “draw scripts”.
- `IRQ` is used for split-screen or raster effects (MMC3 scanline counter) and/or precise mid-frame changes.

Primary implementation is in `Bank31_fixed_bank.asm`.

### 2.2 Engine subsystems
From the folding sections and call patterns, the disassembly centers around these subsystems:

1) **Task system / scene system** (Bank31 + Bank24 + Bank7/8)
   - “Scenes” are driven by draw-script bytecode (Bank24).
   - Tasks manage timed behavior (blink, banner, ball animation, etc.).

2) **Rendering pipeline**
   - **Background/UI**: script-driven PPU buffer commands; nametable + attribute writes.
   - **Sprites**: metasprite scripts (Bank9/10) update OAM buffer.
   - **CHR bank switching**: controlled via MMC3 macros to swap tile pages.

3) **Gameplay state machine (on-field)**
   - Bank19/20 manage the on-field flow: kickoff → play select → run/pass/punt/FG → end-of-play resolution.

4) **Player AI + command scripting + collisions**
   - Bank21 interprets “player commands” (for routes, blocks, coverage, etc.) plus collision/grapple/tackle resolution.

5) **Season simulation and statistics**
   - Bank12 handles season sim and stat bookkeeping.

6) **Sound engine**
   - Bank28 interprets music/SFX commands and drives APU registers.
   - Bank29/30 contain the data streams.

---

## 3) Bank-by-bank design notes (the practical “design doc”)

Below: what each major bank/file *is responsible for* and the interfaces to care about when remaking.

### 3.1 `Bank31_fixed_bank.asm` — fixed bank: system + shared engine
**Role:** system initialization, interrupts, shared utilities.

Key sections (from `_F{_...` markers):
- `_RESET_*` — clear RAM/SRAM, init PPU, mirroring, mapper.
- `_NMI_*` — per-frame work: task checks, PPU buffering, CHR updates, joypad reads, RNG.
- `_IRQ` — scanline interrupt routine.
- `_TASK_FUNCTIONS` — general-purpose task runner.
- `_PPU_TRANSFER_FUNCTIONS_*` — buffered PPU update engine (render-on vs render-off paths).
- `_DRAW_RECT_IMAGE`, `_DRAW_LARGE_TEXT`, `_BUFFER_LARGE_TEXT` — UI draw helpers.
- `_PALLETE_FUNCTION` — palette transitions (fade, swap).
- `_PLAY_SOUND` — sets next sound/song to play (bridges to Bank28 engine).
- Data tables: directions, arctan/velocity tables (physics-ish helpers).

MonoGame mapping:
- Replace NMI/PPU buffering with a **Render()** stage that consumes “draw commands”.
- Replace IRQ split-screen effects with layered rendering / camera viewport logic.
- Keep the task system concept: a fixed update tick that advances timers and runs tasks.

### 3.2 `Bank24_draw_script_engine.asm` — UI/background draw-script VM
**Role:** interprets bytecode scripts to update background/UI, do palette ops, CHR swaps, sprite updates, scrolling, etc.

Notable sections:
- `_START_OF_BG_DRAW_SCRIPT_PROCESSING` — script fetch/decode.
- `_BG_SCRIPT_COMMAND_TABLES` — opcode dispatch.
- `_DRAW_TEXT_FROM_SCRIPT` — string/tile drawing.
- Command families: PPU transfers, set PPU addr, IRQ control, scroll, clear, set CHR banks, palette ops, play sound, draw metasprites.
- “Special commands” (`FA` table + `FC`..`FF` jump/end) for complex UI (coin toss, playoff bracket, leaders, etc.).

MonoGame mapping:
- Implement a small **script interpreter** that can run the existing scripts (or re-author them in JSON) to drive menus/cutscenes.
- Replace PPU-addressed operations with a logical **tilemap layer** and a “UI layout” coordinate system.

### 3.3 `Bank17_18_main_game_loop.asm` — front-end flows, menus, season/pro-bowl
**Role:** the “main program” outside of on-field action.

Evidence (section headers): intro/start screen, sound mode, main menu, preseason menu, season main menu, schedule, standings, rankings, leaders, team data, player data, starters screens, playbook change screens, pro-bowl selection screens.

MonoGame mapping:
- Map each `_F{_...` section to a **GameState** / **Screen** class.
- Many screens are likely driven by draw scripts + input loops; re-implement those loops.

### 3.4 `Bank19_20_on_field_gameplay_loop.asm` — on-field high-level state machine
**Role:** orchestrates a play from selection to resolution.

Evidence (section headers):
- Play select and play load (P1/P2)
- Run play / pass play / sack or scramble
- Special teams: punt, FG, onside
- Resolution: TD, safety, touchback, interception, possession change, first down/TOD
- Fumble/recovery logic

MonoGame mapping:
- Implement `OnFieldStateMachine` with explicit states matching these sections.
- Keep deterministic update step; consider recording inputs for replays/tests.

### 3.5 `Bank21_22_play_commands_on_field_logic.asm` — player command scripts + collisions
**Role:** the “behavior engine” for players and moment-to-moment field logic.

Key responsibilities indicated by section names:
- Player command processing (script interpreter)
- Speed/acceleration update
- Collision type checks + collision resolution
- Grapple/popcorn/throws/tumble logic
- Tackle/fumble checks
- Many specific command handlers: coverage, random action, block/chop block, handoff/pitch, pass routes, kickoff location mods, QB dropback/wait-to-pass, celebrate/cry, snap/hike.

MonoGame mapping:
- This becomes your core **simulation layer**:
  - entity state (players/ball),
  - command queue per entity,
  - collision system,
  - animation state.

### 3.6 `Bank20_playcall.asm` — playcall UI
**Role:** play selection menus, play change, playbook drawing and name rendering.

MonoGame mapping:
- Implement a playcall screen with consistent UX; optionally drive it via a script/data file.

### 3.7 Data banks: formations, plays, scripts, sprites, tiles
These banks are mostly *data and tables* that the engines above consume.

- `Bank1_2_team_data.asm`
  - Team structures, rosters, player names, attributes, likely default lineups.
  - **Porting note:** you’ll want to extract this into structured data (JSON/CSV) and build importers.

- `Bank3_formation_metatile_data.asm`
  - Formation IDs → pointer tables.
  - Background metatiles used in menus/scenes.

- `Bank4_def_spec_play_pointers_data.asm` and `Bank5_6_off_def_play_data.asm`
  - Core play data: routes/blocks/assignments as command streams.
  - **Porting note:** treat these as “script assets” for your Bank21 command interpreter.

- `Bank7_scene_scripts.asm` / `bank8_scene_scripts.asm`
  - Cutscene and static screen scripts for Bank24.

- `Bank9_sprite_scripts.asm` / `Bank10_sprite_scripts.asm`
  - Metasprite scripts; how complex characters and UI sprite composites are assembled.

- `Bank11_12_BG_metatile_tiles.asm`
  - Tile/metatile data for backgrounds.

- `Bank14_pal_fall_player_anim.asm`
  - Palette sets + player “fall” animations. Good reference for animation state machines.

- `Bank15_faces_playbooks.asm`
  - Face graphics mapping and playbook structures.

### 3.8 Season simulation + stats
- `Bank12_13_sim_update_stats.asm`
  - Updates stats, simulates games, season bookkeeping.

MonoGame mapping:
- Separate “SeasonSim” module; keep it headless and unit-testable.

### 3.9 Sound
- `Bank28_sound_engine.asm` — sound command VM + tables.
- `Bank29_sound_data.asm`, `Bank30_sound_data.asm` — the music/SFX command streams.
- `Bank32_DMC_Samples_reset_vector.asm` — DMC samples + vectors.

MonoGame mapping:
- You can emulate the engine (interpret command streams and route to modern audio), or
- Extract melodies/events into MIDI-ish sequences and implement with an audio library.

---

## 4) MonoGame remake blueprint (what to build first)

### 4.1 Suggested C# module breakdown
- `Core/` — timing, deterministic step, RNG, input sampling
- `NesCompat/` (optional) — helpers to interpret legacy scripts/data
- `Rendering/` — sprite batching + tilemap renderer + palette emulation
- `UI/` — screen system + menu widgets
- `Sim/` — on-field simulation (players/ball, collisions, commands)
- `Season/` — schedule, standings, sim, stats
- `Audio/` — sound manager (optionally interprets Bank28 streams)
- `ContentPipeline/` — extract/convert assets from ROM/disassembly into MG-friendly formats

### 4.2 MVP path (pragmatic)
1) Build the **screen/state framework** (start screen → menu) using simple placeholder art.
2) Build **tilemap rendering** and a minimal “draw script” interpreter (enough to draw menus).
3) Build **on-field camera + basic player sprites**.
4) Implement **player command interpreter** for a tiny subset (snap → QB dropback → simple run).
5) Add collision/tackle resolution incrementally.

---

## 5) What I still need to make this truly “exhaustive” (next pass)

If you want the *next level* of thoroughness (function-level, data-structure-level), I can generate a second document that includes:
- extracted TOCs of every bank (`_F{_...` list per file)
- a cross-reference of key RAM variables (from `zero_page_variables.asm`, `ram_variables.asm`, `sram_variables.asm`)
- callgraph-ish maps for the on-field loop and the draw-script engine
- a proposed schema for exporting play data + rosters into modern data files

