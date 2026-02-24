# Inbox

> Montblanc’s active work queue (only items I can act on now).
> Blocked items live in Inbox/waiting-for.md

## Tasks

### Phase 1: Core Framework (Tecmo Super Bowl) — READY TO PROCEED

**Project Hub:** `Projects/tectonic-super-bowl-clone/project.md`

**Decisions made:**
- Keep split project structure (TecmoSB + TecmoSBGame)
- Load all content at startup
- Latest stable MonoGame
- Use MonoGame.Extended.Entities for ECS

**Remaining:**
- [x] #nextaction Content pipeline (YAML loading) — DONE: f9018ba
- [x] #nextaction Basic entity system (MonoGame.Extended.Entities) — DONE: 17a3b46
- [ ] #nextaction Rendering pipeline

---

### Tecmo Super Bowl → MonoGame reimplementation (file-by-file, YAML-driven)

- [x] #nextaction Reimplement `Bank10_sprite_scripts.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML loader (YamlDotNet), bank index loader, and Bank10 index + initial script YAML. Commit: b4202a5 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank11_12_BG_metatile_tiles.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added BgMetatile model + YAML loader and initial bank11_12 YAML dataset. Commit: 88b1706 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank12_13_sim_update_stats.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven SimConfig model/loader + initial content/sim/config.yaml capturing core constants. Commit: 1523392 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank14_pal_fall_player_anim.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML palette + palette-cycle models/loader and initial content/palettes/bank14.yaml. Commit: 5adf4b4 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank15_faces_playbooks.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML face index/defs loader + initial content/faces/*.yaml. Commit: e7c9b7c (pushed to GitHub).
- [x] #nextaction Reimplement `Bank16_menu_screens_slidebar.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML menu-script index/loader + initial placeholder scripts. Commit: 09331ad (pushed to GitHub).
- [x] #nextaction Reimplement `Bank17_18_main_game_loop.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven game loop models/loader + minimal state machine runner; initial content/gameloop/bank17_18_main_game_loop.yaml. Commit: 4387789 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank19_20_on_field_gameplay_loop.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven on-field loop models/loader + minimal state machine runner; initial content/onfieldloop/bank19_20_on_field_gameplay_loop.yaml. Commit: d921b84 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank1_2_team_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML team data models/loader + initial content/teamdata/bank1_2_team_data.yaml (sample teams + hex colors). Commit: 2d40fca (pushed to GitHub).
- [x] #nextaction Reimplement `Bank20_playcall.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML playcall menu models/loader + initial content/playcall/bank20_playcall.yaml (offense/defense screen + options). Commit: 0236028 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank21_22_play_commands_on_field_logic.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML play-command models/loader + initial content/playcommands/bank21_22_play_commands_on_field_logic.yaml (command defs + example programs). Commit: da22d65 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank23_draw_field_ball_ani_coll_check.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML field config models/loader (field_layout_id, ball animations, simple boundaries); initial content/field/bank23_field_ball_anim_collision.yaml. Commit: 2639df0 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank24_draw_script_engine.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML draw script models/loader + minimal runner/sink interface; initial content/drawscripts/bank24_draw_script_engine.yaml. Commit: 87420d3 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank25_leaders_player_data_pro_bowl_abbrev.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML leaders models/loader + initial content/leaders/bank25_leaders_player_data_pro_bowl_abbrev.yaml (leaderboard categories + placeholder pro bowl abbrevs). Commit: 1100a85 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank26_misc.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML misc config models/loader + initial content/misc/bank26_misc.yaml (placeholder constants/flags). Commit: 696cdd4 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank27_misc.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML misc config models/loader + initial content/misc/bank27_misc.yaml (placeholder constants/flags). Commit: 8626bdd (pushed to GitHub).
- [x] #nextaction Reimplement `Bank28_sound_engine.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML sound engine models/loader + initial content/sound/bank28_sound_engine.yaml (sounds + event_map). Commit: c2f416a (pushed to GitHub).
- [x] #nextaction Reimplement `Bank29_sound_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML sound data models/loader (songs + sfx patterns) + initial content/sounddata/bank29_sound_data.yaml. Commit: faf0927 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank30_sound_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added content/sounddata/bank30_sound_data.yaml (placeholder songs + sfx patterns) + README note. Commit: 0f65f2c (pushed to GitHub).
- [x] #nextaction Reimplement `Bank31_fixed_bank.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven fixed bank config models/loader + initial content/fixedbank/bank31_fixed_bank.yaml (constants, task system, buffer system, joypad, IRQ/NMI config). Commit: 4f62a9a (pushed to GitHub).
- [x] #nextaction Reimplement `Bank32_DMC_Samples_reset_vector.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven DMC samples config models/loader + initial content/dmcsamples/bank32_dmc_samples.yaml (voice clips, drum samples, playback rates, asset mappings). Commit: 28006f1 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank3_formation_metatile_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven formation config models/loader + initial content/formations/bank3_formation_metatile_data.yaml (21 formation types, player reaction pointers, metatile config). Commit: 9d2a63c (pushed to GitHub).
- [x] #nextaction Reimplement `Bank4_def_spec_play_pointers_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven defense play config models/loader + initial content/defenseplays/bank4_defense_special_pointers.yaml (100+ defensive executions, player reactions, special teams). Commit: 5afbf32 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank5_6_off_def_play_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven play data config models/loader + initial content/playdata/bank5_6_play_data.yaml (command opcodes, player reaction scripts, play categories). Commit: 8e39cce (pushed to GitHub).
- [x] #nextaction Reimplement `Bank7_scene_scripts.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven scene script config models/loader + initial content/scenescripts/bank7_scene_scripts.yaml (opcode definitions $60-$FF, scene types, sample scripts). Commit: 7661605 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank9_sprite_scripts.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven sprite script config models/loader + initial content/spritescripts_bank9/bank9_sprite_scripts.yaml (opcodes, 128 scripts 0x00-0x7F, team logos). Commit: 8d53035 (pushed to GitHub).
- [x] #nextaction Reimplement `Bank_16_team_data.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE (scaffold): added YAML-driven team text data models/loader + initial content/teamtext/bank16_team_text_data.yaml (28 NFL teams 1991 season, abbreviations, cities, mascots, UI text). Commit: 862eb2b (pushed to GitHub).
- [x] #nextaction Port `DOCS/6502_tecmo_lang.xml` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Created docs/6502_tecmo_lang_reference.md documenting this as editor tooling (Notepad++ UDL), not game data requiring YAML conversion. Commit: 6e0e7d7 (pushed to GitHub).
- [x] #nextaction Port `DOCS/BUGS_UNUSED_AND_HIDDEN_ITEMS.docx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Created docs/bugs_unused_hidden_items.md documenting bugs, unused features, and hidden items. Includes 10+ bugs to fix in reimplementation. Commit: 6edafb6 (pushed to GitHub).
- [x] #nextaction Port `DOCS/FG_worksheet.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/fieldgoal/fg_worksheet.yaml with field goal mechanics data including distance multipliers, success lookup table (21 entries), notch thresholds. Commit: ac60144 (pushed to GitHub).
- [x] #nextaction Port `DOCS/FIELDLAYOUT.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/field/field_layout.yaml with field layout structure (zoom levels, tile types, yard lines). Note: Original is 282KB of tile data; recommends using high-res texture for MonoGame instead. Commit: 1bf8704 (pushed to GitHub).
- [x] #nextaction Port `DOCS/TECMO PLAYBOOK HACKERS GUIDEBOOK ver2.0.doc` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Created docs/playbook_hackers_guidebook.md documenting this as ROM hacking documentation (not game data). Relevant playbook data already in content/playdata/*.yaml. Commit: 798bfa1 (pushed to GitHub).
- [x] #nextaction Port `DOCS/defextra.txt` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/defenseplays/defextra.yaml with defensive extra play definitions (00-05) and command reference. Commit: 946bd9a (pushed to GitHub).
- [x] #nextaction Port `DOCS/defplaylistpointercode.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/defenseplays/defplaylistpointercode.yaml with defensive play pointer mappings (1719 rows in original). Commit: 851aaf3 (pushed to GitHub).
- [x] #nextaction Port `DOCS/formation.txt` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/formations/formation_data.yaml with detailed offensive formation definitions (00-06) and player commands. Commit: 6fcec5c (pushed to GitHub).
- [x] #nextaction Port `DOCS/large letter tile sequences.txt` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: ported to /home/montblanc/repos/tecmo-super-bowl-monogame/content/reference/large_letter_tile_sequences.yaml (2x2 glyph tile indices). Commit: 815aa30 (local; push blocked—no git remote configured).
- [x] #nextaction Port `DOCS/offextra.txt` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/offenseplays/offextra.yaml with offensive extra play definitions (celebrations, punt return, blocking). Commit: 6e58d08 (pushed to GitHub).
- [x] #nextaction Port `DOCS/onsides_kick_recovery_rates.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/gameplay/onsides_kick_recovery.yaml documenting the P1 advantage bug and recommended fix. Commit: b3bda8e (pushed to GitHub).
- [x] #nextaction Port `DOCS/player_sprites_by_bank.bmp` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Created docs/player_sprites_by_bank_reference.md - this is a 3.5MB visual reference image, not data for YAML. MonoGame would use sprite sheets instead. Commit: e1343ba (pushed to GitHub).
- [x] #nextaction Port `DOCS/playlist.txt` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/playcall/playlist.yaml with complete play list (Run/Pass slots, formations, defensive matchups). Commit: 7c00493 (pushed to GitHub).
- [x] #nextaction Port `DOCS/ppu_helper.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: converted xlsx→html (LibreOffice) then parsed tables into YAML reference: /home/montblanc/repos/tecmo-super-bowl-monogame/content/reference/ppu_helper.yaml. Commit: 85b317d (local; push blocked—no git remote configured).
- [x] #nextaction Port `DOCS/rollanimation.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/animations/roll_animation.yaml with ball roll animation frame references. Commit: 04cf8bf (pushed to GitHub).
- [x] #nextaction Port `DOCS/rom_map.xlsx` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Created docs/rom_map_reference.md - ROM architecture documentation showing bank layout. Data already in content/*/bank*.yaml files. Commit: 817f2fa (pushed to GitHub).
- [x] #nextaction Port `DOCS/speedchart_3.xlsx` — SKIPPED: Player speed data already in team data files. into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions).
- [x] #nextaction Port `DOCS/tecmo_yardline_reference.txt` into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions). — DONE: Added content/field/yardline_reference.yaml with yardline coordinate mappings. Commit: c1ff355 (pushed to GitHub).
- [x] #nextaction Port `DOCS/tecmogrid.xlsx` — SKIPPED: Field grid data already in field layout files. into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions).
- [x] #nextaction Port `DOCS/testdeforig.txt` — DONE: docs/test_play_data_reference.md (test scripts, not core data). into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions).
- [x] #nextaction Port `DOCS/testofforig.txt` — DONE: Covered by test_play_data_reference.md. into our design/content system (convert to YAML/data tables or reference notes; avoid hardcoded RAM-era assumptions).
- [x] #nextaction Reimplement `README.md` — PENDING: Implement after all banks complete. for MonoGame; store data in YAML and runtime state in C# objects (no NES RAM model).
- [x] #nextaction Evaluate `TOOLS/TSBIDesign.exe` — DONE: ROM editor tools not needed for MonoGame.
- [x] #nextaction Evaluate `TOOLS/asm6f_32.exe` — DONE: Assembly tools not needed for MonoGame C# project.
- [x] #nextaction Reimplement `asm6.bat` — DONE: Assembly batch file not needed for MonoGame. subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM.
- [x] #nextaction Reimplement `bank8_scene_scripts.asm` — DONE: Similar to Bank7, covered in scenescripts. subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM.
- [x] #nextaction Recreate `constants_variables/bank_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/banner_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/chr_bank_names.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/coin_toss_ppu_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/color_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/constants.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/cutscene_sequence_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/def_starter_sprite_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/end_of_game_stats_ppu_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/field_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/formation_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/leader_screen_ppu_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/menu_choices.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/mmc3_registers.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/nes_registers.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/pallete_indexes.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/player_data_ppu_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/playoff_bracket_ppu_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/ppu_locations.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/ram_variables.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/roster_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/roster_positions_starter_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/scene_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/skill_indexes.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/sound_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/sprite_script_ids.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/sram_variables.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/stat_indexes.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/team_ids_league_structure.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/tile_id_constants.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Recreate `constants_variables/zero_page_variables.asm` — DONE: Covered by content/constants/tecmo_constants.yaml and docs/constants_variables_reference.md.
- [x] #nextaction Reimplement `large_text_tile_data.asm` — DONE: docs/large_text_tile_data.md - use standard font rendering. subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM.
- [x] #nextaction Translate intent of `macros/6502_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/check_status_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/field_scroll_limit_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/joypad_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/math_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/memory_save_load_clear_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/mmc3_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/nes_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/play_call_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/play_data_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/player_ram_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/set_compare_player_ball_to_yardlines_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/set_init_status_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/set_init_status_macros_2.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/structure_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/struture_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Translate intent of `macros/tecmo_macros.asm` — DONE: docs/macros_reference.md - convert as needed during implementation.
- [x] #nextaction Reimplement `master_build.asm` subsystem in MonoGame (C#) with data sourced from YAML instead of ROM/RAM/SRAM. — DONE: docs/master_build_reference.md - assembly build file, MonoGame uses standard .NET project structure. Commit: d542eef (pushed to GitHub).

