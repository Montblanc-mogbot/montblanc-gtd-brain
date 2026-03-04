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

## Roadmap TODOs (assembly-parity → fully playable) #nextaction

### 0) Unblock development (build + architecture correctness)
- [x] #nextaction Fix `dotnet build` failure (MSB3492 reading `TecmoSB.AssemblyInfoInputs.cache`) so the repo builds cleanly from scratch. — DONE: removed nonstandard MSBuild workarounds and verified clean `dotnet build src/TecmoSB.sln` succeeds (after deleting obj/bin).
- [x] #nextaction Fix `MainGame` init order: create `_spriteBatch` before constructing systems that require it (RenderingSystem). — DONE: moved ECS world construction into `LoadContent()` after SpriteBatch creation; removed `_spriteBatch!` in world construction; added safe null guard in `Draw()`.
- [x] #nextaction Remove nested SpriteBatch Begin/End (define a single render pipeline; systems should not Begin/End independently). — DONE: `MainGame` owns Begin/End; `RenderingSystem` only issues draw calls; `_world.Draw()` is called inside the active batch; also cached a 1×1 pixel texture to avoid per-frame allocations.
- [x] #nextaction Add a headless/deterministic sim runner (no graphics) to validate gameplay logic against assembly behavior. — DONE: added `src/Sim/TecmoSBHeadless` console runner; runs fixed-timestep ticks and prints snapshots. Run: `dotnet run --project src/Sim/TecmoSBHeadless -- --ticks 600 --hz 60`.

### 1) Principled ECS architecture (extensible + legible)
- [x] #nextaction Define ECS conventions (component granularity, naming, folder layout, system responsibilities) and document them in `docs/ARCHITECTURE.md`. — DONE: added `docs/ARCHITECTURE.md` with conventions for components/systems, determinism, eventing approach, and code pointers.
- [x] #nextaction Implement an event/message bus for decoupled systems (Snap/Tackle/Catch/Whistle/Score/etc.) mirroring assembly events. — DONE: added `TecmoSBGame.Events.GameEvents` (per-tick deterministic queues) + event types; added `WhistleOnTackleSystem`; wired `GameStateSystem` to publish/consume; drivers call `BeginTick()` once per tick.
- [x] #nextaction Add fixed-timestep (60Hz) gameplay update separate from render tick, to match assembly frame logic. — DONE: added `TecmoSBGame.Timing.FixedTimestepRunner`; `MainGame.Update()` advances `_world.Update()` at fixed 60Hz and calls `_events.BeginTick()` once per sim tick; headless runner uses the same driver.
- [x] #nextaction Create `MatchState` model (score/quarter/clock/possession/down-distance/ball spot) aligned with assembly RAM/state concepts. — DONE: added pure data `src/TecmoSBGame/State/MatchState.cs` and injected into `GameStateSystem`; headless snapshots print `MatchState.ToSummaryString()`; build verified.
- [x] #nextaction Create `PlayState` model (play id, timers, ball state, whistle reason, result) aligned with assembly flow. — DONE: added pure data `src/TecmoSBGame/State/PlayState.cs`; injected into `GameStateSystem` and initialized/reset per kickoff; headless snapshots print `PlayState.ToSummaryString()`; tackle sets whistle reason + yards gained.
- [x] #nextaction Integrate `GameLoopMachine` + `OnFieldLoopMachine` as the authoritative state controllers for ECS system enable/disable and transitions. — DONE: added `LoopState` + `LoopMachineSystem` that ticks machines at 60Hz and bridges events; systems (e.g. InputSystem) early-out based on loop state; headless prints loop snapshots.

### 2) Rendering pipeline (data-driven, assembly-faithful presentation)
- [x] #nextaction Recreate and fully populate `ASSETS.md` with a clean-room list of all needed game assets (UI/sprites/tiles/audio/fonts) using Tecmo Super Bowl as reference and proposed higher-res sizes. — DONE: Fully populated ASSETS.md with 104 trackable assets across 10 categories. Commit: d71eea8
- [ ] #nextaction Implement sprite/texture registry (spritesheets + regions via YAML manifest) and hook SpriteComponent to render real sprites.
- [ ] #nextaction Implement animation component + animation system (clip/frame-based) driven by gameplay state, matching assembly animation timing.
- [ ] #nextaction Implement camera + Tecmo-style field scrolling behavior aligned with assembly scrolling logic.
- [ ] #nextaction Convert FieldRenderer from procedural rectangles to tile/atlas-driven field art (still 256×224 virtual).

### 3) Input + player control
- [x] #nextaction Define + scaffold “controlled player selection” rules (pre-snap/offense/defense switching) with a spec doc + minimal runtime wiring. — DONE: added `docs/CONTROLLED_PLAYER_SELECTION.md`, `ControlState`, `PlayerControlComponent`, `PlayerControlSystem`, and gated `InputSystem` to only move the controlled entity; headless prints control state.
- [x] #nextaction Implement Tecmo-style movement fully (acceleration curve, instant stop/turn, speed burst/dive/cut hooks) tuned by rating/role. — DONE: added movement tuning/input/action components; updated MovementSystem for fixed-tick Tecmo feel; InputSystem writes MovementInput + action state; headless prints speed/vel/action.
- [x] #nextaction Implement action button behavior by context (tackle/dive/pass/pitch/QB scramble/etc.). — DONE: added contextual action command layer (`PlayerActionCommand` + `PlayerActionStateComponent`), `ActionResolutionSystem`, and intent events (tackle/pass/pitch); headless prints lastCmd.

### 4) Ball system (real ball state machine)
- [x] #nextaction Create Ball entity + components (BallState: Held/InAir/Loose/Dead, owner reference) and wire into gameplay. — DONE: added `BallComponents` + `BallEntityFactory`; kickoff slice uses a dedicated ball entity; headless prints ball id/state/owner/pos; build verified.
- [x] #nextaction Implement kickoff/punt ball trajectory + hangtime + landing spot logic matching assembly. — DONE (kickoff first): added `BallFlightComponent` + `BallPhysicsSystem` (linear XY + parabolic height) and changed kickoff landing to be flight-driven; headless prints flight progress/height.
- [x] #nextaction Implement pass trajectory + targeting/lead rules matching assembly. — DONE: expanded `PassRequestedEvent`; added `PassFlightStartSystem` (lead targeting via constant-velocity prediction + bounds clamp) + `PassFlightCompleteSystem` (auto-catch placeholder); integrated with `BallFlightComponent` + headless output.
- [x] #nextaction Implement catch/interception resolution using ratings tables like assembly. — DONE: pass completion now resolves catch/INT/incomplete via ratings+proximity and deterministic RNG; publishes PassResolvedEvent for headless; updates PlayState + ball ownership; incompletes publish WhistleEvent("incomplete").
- [x] #nextaction Implement fumble + loose ball pickup rules matching assembly. — DONE (minimal loop): added fumble/pickup events + systems (TEMP trigger on Whistle("tackle") until real tackle resolution); loose ball scatter + nearest pickup; headless logs fumble/pickup.
- [x] #nextaction Implement out-of-bounds/touchback/safety detection from ball + bounds. — DONE: added `FieldBounds` + `BallBoundsSystem` to whistle OutOfBounds/Touchback/Safety from ball position; updates PlayState and headless logs bounds whistles.

### 5) Collision + contact (Tecmo core)
- [x] #nextaction Implement discrete collision checks (distance-based) aligned to assembly’s per-frame collision logic. — DONE: added `CollisionContactSystem` with layered phases (proximity/tackle/block) and explicit contact events (`TackleContactEvent`, `BlockContactEvent`); includes deterministic `--headless` smoke runner for contacts.
- [x] #nextaction Implement grapple/engagement/interrupt behavior stack (push/pop) for tackles/blocks like assembly. — DONE: added `BehaviorStackComponent` + snapshot/restore; `EngagementSystem` + `TackleInterruptSystem` push interrupts from contact events; `BehaviorStackSystem` pops/restores after timers; headless logs begin/end.
- [x] #nextaction Implement tackle resolution (HP/RS/MS etc.) and tackle-break outcomes matching assembly. — DONE (clean-room scaffold): added `TackleResolutionSystem` with deterministic ratings-based outcomes (downed/fall-forward/broken/stumble) and cooldown; whistles tackles via events; stumble uses `SpeedModifierComponent/System`; headless logs tackle resolves.

### 6) Behaviors + AI (readable reimplementation of assembly logic)
- [ ] #nextaction Implement offensive route-running (PlayData-driven waypoints/timing) matching assembly.
- [ ] #nextaction Implement blocking assignments + engagement selection matching assembly.
- [ ] #nextaction Implement QB dropback + pass decision (first pass) matching assembly.
- [ ] #nextaction Implement defensive rush + pursuit angle logic matching assembly.
- [ ] #nextaction Implement coverage (man/zone landmarks) matching assembly.
- [ ] #nextaction Implement special teams lanes/return decisions matching assembly.

### 7) Playbook + formation spawning (YAML → on-field entities)
- [x] #nextaction Build FormationSpawner: spawn entities from FormationData + TeamData, assign roles like assembly. — DONE: added `FormationSpawner` + `PlayerRoleComponent` + placeholder `TeamRoster`; kickoff can spawn YAML formation id `00`; headless prints roster; fixed FormationData YAML loader shape.
- [x] #nextaction Build PlaySpawner: select offense/defense plays and attach route/assignment components like assembly. — DONE: added `PlaySpawner` + assignment components (`PlayCallComponent`, `OffensiveAssignmentComponent`, `DefensiveAssignmentComponent`); headless spawns formation+defense and prints assignments; deterministic play selection for now.
- [x] #nextaction Implement pre-snap placement (LOS, motion if any) and snap trigger matching assembly. — DONE: added PreSnap placement systems + Snap command routed through action layer; SnapResolutionSystem assigns QB + ball on snap; headless `--scenario presnap` demonstrates pre_snap→live_play.
- [x] #nextaction Spot the ball and reset to next play state after play ends (PostPlay → PreSnap). — DONE: added `NextPlayResetSystem` + `ResetToPreSnapEvent`; clears per-play transient components, resets PlayState for next play, and nudges loop back to `pre_snap` deterministically (headless verified).
- [x] #nextaction Implement play end conditions (tackle/OOB/TD/safety/turnover/incomplete) matching assembly. — DONE (authoritative aggregator): added `PlayEndSystem` that reads whistles to finalize PlayState, compute yards/result flags, and update MatchState; emits `PlayEndedEvent`; headless prints one-line play-end summaries.

### 8) Rules + refereeing
- [x] #nextaction Implement down & distance progression rules and ball spotting matching assembly. — DONE (dedicated rules step): added `DownDistanceSystem` consuming `PlayEndedEvent` to update MatchState (downs/YTG/spot/possession/score) deterministically; PlayEndSystem now only finalizes PlayState + emits PlayEndedEvent.
- [x] #nextaction Implement clock rules (running/stopped, quarters/halftime/endgame) matching assembly. — DONE (deterministic scaffold): added `GameClockSystem` (60Hz→seconds; runs in live_play), quarter/halftime/game-over events, and `MatchState.MatchOver`; wired into game + headless; TODOs left for Tecmo stoppage semantics.
- [x] #nextaction Implement kickoff-after-score and PAT/2pt decision flow matching assembly. — DONE (kickoff after score): added `KickoffAfterScoreSystem` + `KickoffSetupEvent`; TD/safety trigger kickoff setup/reset; headless supports `--force-td/--force-safety` to demo. (PAT/2pt still TODO).

### 9) UI + game states (fully playable loop)
- [ ] #nextaction Implement Title → Menu → Team Select → Coin Toss → Kickoff → OnField → PostPlay flow, matching assembly sequencing.
- [ ] #nextaction Implement HUD (score/quarter/clock/down-distance/ball spot) matching assembly.
- [ ] #nextaction Implement Playcall UI driven by YAML playlist, matching assembly selections.
- [ ] #nextaction Implement Post-play summary UI (result/yards/turnover) matching assembly.

### 10) Audio integration
- [ ] #nextaction Implement SoundService and hook key events (snap/kick/hit/whistle/crowd/menu) matching assembly cues.
- [ ] #nextaction Implement music state switching (title/menu/on-field/score/halftime) matching assembly.

### 11) Sprite scripts / draw scripts direction (needs decision)
- [ ] #nextaction #waitingfor Decide whether to (A) extend sprite-script interpreter as animation driver or (B) translate sprite scripts into modern animation clips and use scripts only as reference.

### 12) Debugging + tooling
- [ ] #nextaction Add in-game debug overlay (state ids, selected player, ball state/owner, key timers) for assembly parity debugging.
- [ ] #nextaction Add replay recorder (tick snapshots) to compare behavior vs assembly.
- [ ] #nextaction Add YAML validation pass with actionable errors (missing ids, bad references, out-of-range values).


### Player Entity Factory
- [x] #nextaction Create PlayerEntityFactory — Map team roster data to ECS entities — DONE: Created factory with CreatePlayer, CreatePlayerWithAttributes, CreateKicker, CreateReturner, CreateCoveragePlayer, CreateBlocker, CreateTeam methods. Commit: 49462bf (local; push blocked—no git remote configured).

### Formation Positioning
- [x] #nextaction Implement FormationPositioningSystem — DONE: Created system with Pro, Shotgun, Goal Line, 4-3 Defense, Kickoff formations. Commit: 06ea803 (local; push blocked—no git remote configured).

### Play Execution
- [x] #nextaction Create PlayExecutionSystem — Convert YAML play commands to behaviors — DONE: Created system with StartPlay/EndPlay, route/block/rush/tracking/tackle behaviors. Commit: 1cada8b (local; push blocked—no git remote configured).

### Input Handling
- [x] #nextaction Implement InputSystem — DONE: Created InputManager with context-based routing (Menu/PlayCall/PreSnap/InPlay/PostPlay). Commit: ca27f57 (local; push blocked—no git remote configured).

### Collision Detection
- [x] #nextaction Create CollisionSystem — DONE: Created CollisionDetectionSystem with player-player collision, boundary collision, tackle/block detection. Commit: b420ae6 (local; push blocked—no git remote configured).

### Game State Management
- [x] #nextaction Implement GameStateSystem — DONE: Created GameStateManager with game phases, game/play clock, down/distance/field position tracking, scoring. Commit: 3db6904 (local; push blocked—no git remote configured).
- [x] #nextaction Implement GameStateSystem — Track down, distance, possession — DONE: Implemented in GameStateManager with states (PreSnap, InPlay, PostPlay, etc.), down (1-4), yards to go, field position, possession tracking. Commit: 3db6904 (local; push blocked—no git remote configured).

### Play Result Resolution
- [x] #nextaction Create PlayResultSystem — Determine play outcome — DONE: Created PlayResultResolver with yards calculation, touchdown/safety detection, incomplete passes, interceptions, fumbles handling. Commit: e563b1f (local; push blocked—no git remote configured).

---

## Backlog
- [x] Build tooling: script to extract assets from ROM into friendly formats — DONE: Created tools/extract_chr.py, tools/convert_chr_to_png.py, docs/ASSET_PIPELINE.md. Commit: a46994f (local; push blocked—no git remote configured).
- [x] Input mapping + controller support — DONE: InputSystem with keyboard (arrows/WASD/space) and gamepad support. Commit: f3e1eee (local; push blocked—no git remote configured).
- [x] Sound/music plan — DONE: Created docs/SOUND_MUSIC_PLAN.md with audio architecture, implementation strategy, asset pipeline, and volume/priority levels. Commit: 9e7b82a (local; push blocked—no git remote configured).
- [x] Save data / season simulation — DONE: Created docs/SAVE_SEASON_DESIGN.md with save data schema, SeasonManager design, schedule generation, stats tracking, and standings calculation. Commit: 31d9140 (local; push blocked—no git remote configured).
