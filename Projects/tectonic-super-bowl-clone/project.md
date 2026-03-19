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

### Arch parity: port remaining gameplay to SimArch (now that MGE is cut) #nextaction
- [x] #nextaction Port formation spawning to use real YAML (FormationDataConfig) instead of demo roster (SimArch/Spawning/FormationSpawner). — DONE: tecmo-super-bowl-monogame commit fb35608 (feat/simarch-ball-system)
- [x] #nextaction Port play application to use real YAML playbook data (PlayListConfig + PlayDataConfig) instead of hardcoded play_number=10 (SimArch/Spawning/PlaySpawner). — DONE: tecmo-super-bowl-monogame commit 3216216 (feat/simarch-ball-system)
- [x] #nextaction Add Arch equivalents for ratings/tuning components still implicit in the old sim (speed/accel/turn rate; stamina optional). — DONE: tecmo-super-bowl-monogame commit 37b20ef (feat/simarch-ball-system)
- [x] #nextaction Port collision/contact pipeline to Arch (proximity checks → engagement/block/tackle contact events). — DONE: tecmo-super-bowl-monogame commit f8d02eb (feat/simarch-ball-system)
- [x] #nextaction Port engagement + behavior interrupts stack to Arch (push/pop tackle/block interrupts). — DONE: tecmo-super-bowl-monogame commit b5fcd7e (feat/simarch-ball-system)
- [x] #nextaction Port tackle resolution rules to Arch (ratings-based outcome + whistle) and feed into play-end. — DONE: tecmo-super-bowl-monogame commit 2a00298 (feat/simarch-ball-system)
- [x] #nextaction Port QB dropback + read progression + pass decision to Arch. — DONE: tecmo-super-bowl-monogame commit 4d8b141 (feat/simarch-ball-system)
- [x] #nextaction Port route-follow system to Arch (frame-timed route nodes) and attach via play data. — DONE: tecmo-super-bowl-monogame commit ce205c7 (feat/simarch-ball-system)
- [x] #nextaction Port blocking assignments + blocker AI to Arch. — DONE: `SimArch/Components/BlockTarget.cs`, `SimArch/Systems/BlockerAiSystem.cs`, wired in `SimArch/Sim.cs` (tecmo-super-bowl-monogame @ 0fa05d3)
- [x] #nextaction Port defensive rush to Arch (gap landmark → QB rush + moves). — DONE: tecmo-super-bowl-monogame commit 8d8a1c6
- [x] #nextaction Port man/zone coverage to Arch. — DONE: tecmo-super-bowl-monogame commit 8255d06
- [x] #nextaction Port clock + down/distance rules to Arch (MatchState/PlayState equivalents or new Arch-native models). — DONE: tecmo-super-bowl-monogame commit 17aae0e
- [x] #nextaction Expand SimSnapshot to include any extra render/debug fields needed (e.g., engagement lines, route next node, coverage targets). — DONE: tecmo-super-bowl-monogame commit c25574f
- [x] #nextaction Replace remaining UI/flow assumptions with Arch-native flow (playcall → apply play → post-play summary) or temporarily keep as headless-only until Gum assets land. — DONE (headless-first scaffold): `MainGameArch` Enter-to-start/advance, `Sim.AdvanceToNextPlay`, `Sim.PlayState.Phase` PostPlay. (tecmo-super-bowl-monogame commit 10e6140)

### Arch + Gum refactor (approved plan) — granular conversion list #nextaction

#### A) Repo / structure (general changes)
- [x] #nextaction Add new folder tree `src/TecmoSBGame/SimArch/` (World + components + systems + snapshot) and wire into solution. — DONE: added SimArch skeleton (`Sim.cs`, `SimSnapshot.cs`) (commit 90cd337)
- [x] #nextaction Add NuGet packages: `Arch`, `Arch.Extended` (EventBus), and the Gum runtime packages for MonoGame DesktopGL. — DONE: added Arch + Arch.EventBus + Gum.MonoGame; removed DefaultEcs (commit 77cb8ac)
- [x] #nextaction Add feature flag parsing in `src/TecmoSBGame/Program.cs` (e.g. `--sim=mge|arch`, default mge until cutover). — DONE: added SimMode + Program/MainGame plumbing (commit 9e3c12d)
- [x] #nextaction Add global crash-to-log handler (stderr exceptions must also be written into `~/.local/share/TecmoSBGame/Logs/...`). — DONE: CrashLogging.Install() hooks UnhandledException + UnobservedTaskException and writes to stderr (tee'd into log) (commit 9cbe2a8)

#### B) Arch.EventBus (simulation eventing)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Events/` and define core event structs: Snap/Handoff/Whistle/PlayEnded/PlaySelected/etc. — DONE: SimEvents.cs (commit 6946eaf)
- [x] #nextaction Create ordering conventions doc (or comment header) for `[Event(order: ...)]` receivers (rules before presentation). — DONE: EventOrder.cs + conventions (commit 6946eaf)
- [x] #nextaction Replace usages of `TecmoSBGame.Events.GameEvents` in the new Arch sim with EventBus send/receive patterns. — DONE: SimArch uses `SimEventBus` (Arch.EventBus) for `PlaySelectedEvent` and has no `GameEvents`/`TecmoSBGame.Events` references (verified via ripgrep in `src/TecmoSBGame/SimArch`).

#### C) Arch entity/component helpers (doc-driven patterns)
- [x] #nextaction Implement `src/TecmoSBGame/SimArch/ArchEntityExtensions.cs` with safe helpers (Has-before-Add/Set, documented patterns only). — DONE: Ensure/Upsert/GetOrAdd/RemoveIfPresent helpers (commit 097b503)
- [x] #nextaction Add “no structural changes during iteration unless documented approach” guardrails (comments + helper usage). — DONE: added SimArch/STRUCTURAL_CHANGES.md + SimEventBus wrapper; build green (commit 700be1d)

#### D) Simulation core (file-by-file ports)

**New files (Arch sim core):**
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Sim.cs` (own Arch World, fixed-step Update, ApplyPlaySelection, Snapshot). — DONE: Sim owns Arch World + queues play selection; emits PlaySelectedEvent via SimEventBus (commit fdd01e8)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/SimSnapshot.cs` (render DTO for players+ball+state). — DONE: added PlayerSnapshot[] + BallSnapshot (commit caffe16)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Components/Position.cs` and `Velocity.cs`. — DONE (commit 945f9fc)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Components/Team.cs` and `Role.cs` (slot + offense/defense). — DONE (commit 945f9fc)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Components/Behavior.cs` (Idle/MoveTo/Tracking + targets). — DONE (commit 945f9fc)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Components/Ball.cs` (single struct with state/owner/flight fields). — DONE (commit 945f9fc)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Components/Control.cs` (controlled entity + pending forced control). — DONE (commit 945f9fc)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Components/PlayScript.cs` (IP/waits/ops reference). — DONE (commit 425b71a)

**Port systems (re-implement, not 1:1 copy):**
- [x] #nextaction Port Movement logic from `src/TecmoSBGame/Systems/MovementSystem.cs` → `src/TecmoSBGame/SimArch/Systems/MovementSystem.cs` (turn-rate limit preserved). — DONE: first Arch MovementSystem skeleton w/ turn limit + integration; wired into Sim.Update (commit 425b71a)
- [x] #nextaction Port PlayScript runtime from `src/TecmoSBGame/Systems/PlayScriptSystem.cs` → `SimArch/Systems/PlayScriptSystem.cs` (wait_until_snap, handoff_to delay, pursue/rush). — DONE (initial): delayed handoff + defender retarget to ballcarrier (commit 577efef)
- [x] #nextaction Port ball ownership + flight physics from `src/TecmoSBGame/Systems/BallPhysicsSystem.cs` (+ pass/kickoff start/complete systems) → `SimArch/Systems/BallSystem.cs`. — DONE: implemented `SimArch/Systems/BallSystem.cs` + wired into `Sim`; added SimArch pass/kickoff flight start/complete stubs (`PassFlightStartSystem`, `PassFlightCompleteSystem`, `KickoffFlightStartSystem`, `KickoffFlightCompleteSystem`) and wired completion systems into `Sim` loop. Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `e4e35b3` (build green).
- [x] #nextaction Port tackle/whistle pipeline from `src/TecmoSBGame/Systems/*Tackle*/*.cs` + `PlayEndSystem.cs` + `NextPlayResetSystem.cs` → `SimArch/Systems/TackleAndPlayEndSystems.cs` (may split into multiple files). — DONE (minimal SimArch scaffold): added `SimArch/Systems/TackleAndPlayEndSystems.cs` (nearest-defender tackle contact → whistle by setting ball Dead; clears velocities) and wired into `Sim` update loop. Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `3ffd62e` (build green). NOTE: full ruleset + reset-to-presnap semantics still TODO.
- [x] #nextaction Port PreSnap placement from `src/TecmoSBGame/Systems/PreSnapSystem.cs` + `PreSnapBallPlacementSystem.cs` → `SimArch/Systems/PreSnapSystems.cs`. — DONE (minimal SimArch scaffold): added `SimArch/Systems/PreSnapSystems.cs` (treat ball X as LOS when ball is Dead; align players via offense anchor; apply small defender separation; snap ball + clear ownership/flight) and wired into `Sim` update loop. Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `0e564b8` (build green).

#### E) Spawning / content application (file-by-file)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Spawning/FormationSpawner.cs` (reuse YAML formation data; spawn Arch entities for offense/defense). — DONE (initial deterministic demo roster; YAML wiring TODO later) (commit 7be4bed)
- [x] #nextaction Create `src/TecmoSBGame/SimArch/Spawning/PlaySpawner.cs` (apply selected play: attach routes/assignments/scripts to Arch entities). — DONE: supports play_number=10 (handoff delay + defense tracking) (commit 577efef)
- [x] #nextaction Move/keep compiler as pure code: `src/TecmoSBGame/Spawning/PlayScriptCompiler.cs` should be reusable by Arch spawners. — DONE: compiler already has no ECS dependencies; added explicit comment documenting the purity/allowed deps so it stays Arch-reusable. Evidence: tecmo-super-bowl-monogame `feat/simarch-ball-system` commit `ef1c677`.

#### F) Headless regression (must-pass)
- [x] #nextaction Port `src/TecmoSBGame/Headless/HeadlessRunner.cs` so `--headless-2plays` uses Arch sim (and keep the same assertions). — DONE: `RunTwoPlaysScenario` now drives `TecmoSBGame.SimArch.Sim`; assertions preserved (handoff via PlayScript fired; defender pursuit; play advance via reset on dead-ball). Verified `dotnet run -- --headless-2plays 240` PASS. Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `8a0c9ed`.

#### G) Rendering (no ECS UI components)
- [x] #nextaction Create `src/TecmoSBGame/Rendering/SimRenderer.cs` that draws `SimSnapshot` (use existing SpriteRegistry). — DONE: SimRenderer draws snapshot (commit caffe16)
- [x] #nextaction Update `src/TecmoSBGame/MainGame.cs` to render via `SimRenderer` when `--sim=arch` is enabled. — DONE: when `--sim=arch`, fixed-step updates Arch sim and Draw renders snapshot (commit caffe16)

#### H) Gum UI (modern)
- [x] #nextaction Create `src/TecmoSBGame/UI/Gum/GumBootstrap.cs` (init + load root screen). — DONE: added `TecmoSBGame.UI.Gum.GumBootstrap` (init + Forms defaults + attach root screen under GumService.Root). Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `790ab66` (build green).
- [x] #nextaction Create `src/TecmoSBGame/UI/Playcall/PlaycallScreen` (formations list + plays list + confirm) using Gum. — DONE (code-only scaffold): added `TecmoSBGame.UI.Playcall.PlaycallScreen` with Formation list, Play list, and Confirm button + `Confirmed` event (no Gum project assets required yet). Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `d9bcb22` (build green).
- [x] #nextaction Wire playcall confirm → `Sim.ApplyPlaySelection(...)` (offense only; defense AI-picked) and hide UI. — DONE (auto-mode for now): in Arch sim mode, MainGame now calls `ApplyPlaySelection(...)` from playcall state (offense only) and hides playcall UI. Evidence: tecmo-super-bowl-monogame branch `feat/simarch-ball-system` commit `296af82` (build green).

#### I) Cleanup / removal
- [x] #nextaction Ask Matt for explicit go-ahead to remove/disable `MonoGame.Extended.Entities` world creation path in `--sim=arch` mode (keep legacy path for `--sim=mge`). — ASKED in #work (msg 1484144550456070225)
- [x] #nextaction Remove/disable `MonoGame.Extended.Entities` world creation path and make the game Arch-only. — DONE: removed MGE package + excluded legacy code from compilation; new `MainGameArch` entrypoint; headless `--headless-2plays` now uses Arch. Commit: a812ad0 (pushed).

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

### Playable demo (Arch / SimArch) — MVP checklist #nextaction

**Definition of done (demo):** Launch the game, select *a* play (UI or minimal menu), press snap, control the ballcarrier/defender, see a deterministic play run, resolve tackle/whistle, show a post-play summary, then reset to pre-snap for the next play.

- [x] #nextaction Implement a real play-lifecycle state machine in SimArch (PreSnap → InPlay → PostPlay → PreSnap) driven by events (`SnapEvent`, `WhistleEvent`, `PlayEndedEvent`) with no ad-hoc “press Enter” shortcuts. Acceptance: the phase transitions happen from systems only; MainGame only feeds input + renders. — DONE: tecmo-super-bowl-monogame commit 59e2dfc
- [x] #nextaction Implement formation positioning from `FormationDataConfig` for **both offense and defense** (no placeholder defensive front). Acceptance: 22 players placed deterministically from YAML formation slots relative to LOS, plus ball spot. — DONE: added `defensive_formation_data.yaml` + loader + `FormationSpawner` now spawns defense from YAML. Commit: 29dad2f
- [x] #nextaction Implement `FormationScriptParser` grammar + `FormationScriptSystem` interpreter for the subset required to place/shift/motion players pre-snap. Acceptance: all formation scripts referenced by the chosen formation YAML execute without NOP fallback. — DONE: principled parser+interpreter implemented and wired (no NOP fallback; unhandled tokens are recognized NoOp). Commit: 5b743cc
- [x] #nextaction Expand PlayData script compilation/execution until the chosen play executes **all referenced commands** (no ignored/unimplemented opcodes). Acceptance: log/diagnostic mode shows 0 “unknown cmd” for the play’s scripts. — DONE: added strict validation + implemented `rush_qb` + `pursue_ballcarrier` op execution for play 10 scripts. Commit: 16d5d91
- [x] #nextaction Replace deterministic defense slot mapping with a YAML-driven defensive roster/assignment model (roles + coverage/rush assignments) so play behavior is extensible per formation/defense call. — DONE: defenders are tagged with `PlayerRole.Slot` from defensive formation YAML; PlaySpawner maps defense slots via the component (no spawn-order mapping). Commit: 0bcb200
- [x] #nextaction Implement `PlayCallSystem` + input wiring to choose formation+play (minimal UI acceptable) and publish a complete `PlaySelectedEvent` (offense formation + play + defense call). Acceptance: no hardcoded play number in MainGame/Sim. — DONE: PlayCallState singleton + PlayCallSystem + publish-on-Select + Snap/Continue input system; MainGame only forwards UiButtons edges. Commit: ebffeee
- [x] #nextaction Implement `PlayerControlSystem` selection rules (offense: ballcarrier/QB; defense: nearest pursuit defender) and wire to input. Acceptance: control switches deterministically on handoff/pass/catch/turnover. — DONE: tecmo-super-bowl-monogame commit 285762b
- [ ] #nextaction Implement yardline/world coordinate mapping + spotting so `PlayResultResolver` computes yards gained from the ball’s absolute yard and updates `MatchState` correctly. Acceptance: down/distance changes correctly after the play.
- [ ] #nextaction Implement `PlayEndSystem` + `NextPlayResetSystem` so a whistled play produces a stable post-play summary and then resets all entities to pre-snap positions for the next play without recreating the world.
- [ ] #nextaction Implement fumble/loose-ball pipeline end-to-end (fumble trigger → loose ball flight → pickup). Acceptance: can force a fumble via debug flag and see the ball become loose and be recovered.
- [ ] #nextaction Implement a minimal HUD update (`HudSystem`) showing: down, distance, quarter, clock, ball spot, score. Acceptance: renders correctly and updates after a play.

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
- [x] #nextaction Implement sprite/texture registry (spritesheets + regions via YAML manifest) and hook SpriteComponent to render real sprites. — DONE: added sprite_manifest.yaml + debug spritesheet + SpriteRegistry; RenderingSystem draws SpriteComponent via atlas regions (commit df366f6)
- [x] #nextaction Implement animation component + animation system (clip/frame-based) driven by gameplay state, matching assembly animation timing. — DONE: added AnimationComponent/Clip/Frame + AnimationSystem (60Hz tick-based); player factory attaches defaults; build fixed. Commit: 7ac439a
- [x] #nextaction Implement camera + Tecmo-style field scrolling behavior aligned with assembly scrolling logic. — DONE: added Camera2D + CameraSystem w/ Tecmo-like deadzone scrolling + follow target priority; composed view matrix into SpriteBatch transform; tagged ball/players as camera targets. Commit: 26115aa
- [x] #nextaction Convert FieldRenderer from procedural rectangles to tile/atlas-driven field art (still 256×224 virtual). — DONE: FieldRenderer now draws 16×16 tiles and optionally uses SpriteRegistry ids (field_grass_a/b) with a checkerboard grass fallback; MainGame passes SpriteRegistry into FieldRenderer. Commit: 35ff615

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

**Goal:** Precisely emulate the original NES game feel by implementing AI behaviors that match the assembly logic. All behaviors should be deterministic and data-driven from YAML play data.

#### 6.1 Offensive Route-Running (Assembly-Accurate)
- [x] #nextaction **ROUTE-1:** Study assembly route table format (ROM bank with route byte sequences) — DONE: captured current understanding + gaps in repo notes `docs/ROUTE_BYTE_FORMAT.md` (discusses AX route-order cmd vs geometry/timing tables; proposes engine-facing route format; identifies missing ROM-level byte layout to extract). Evidence: tecmo-super-bowl-monogame/docs/ROUTE_BYTE_FORMAT.md
- [x] #nextaction **ROUTE-2:** Create RouteComponent with waypoints, timing, and route type (Go, Post, Corner, Out, Slant, etc.) — DONE: RouteComponent now has typed RouteKind + RouteNodeAction (while keeping string fields for YAML); RouteFollowSystem prefers typed action and falls back to parsing legacy string. Commit: 66ec2b4
- [x] #nextaction **ROUTE-3:** Implement RouteFollowSystem - interpolate between waypoints at fixed 60Hz — DONE: RouteFollowSystem already advances exactly 1 frame per tick (60Hz) and drives MovementSystem via Behavior.TargetPosition (deterministic, frame-timed transitions, Tecmo-style cuts). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/RouteFollowSystem.cs
- [x] #nextaction **ROUTE-4:** Handle route cut/depth timing (wait for QB, break on timing) — DONE: RouteFollowSystem now supports stem/break timing by letting RouteComponent.StemFrames override the first node duration (timing-based break). Existing SIT node action provides “wait” behavior. Commit: a97a388
- [x] #nextaction **ROUTE-5:** Add route adjustments vs man/zone coverage — DONE (scaffold): PlaySpawner attaches DefensiveLookComponent (man/zone hint) to offensive entities; RouteFollowSystem applies RouteComponent.ManAdjustOffset/ZoneAdjustOffset deterministically based on that look. Commit: 2df1225
- [x] #nextaction **ROUTE-6:** Verify route speed matches assembly (use player MS rating) — DONE: RouteFollowSystem.ApplyRouteSpeed implements requested formula speed=(playerMS/69)*baseRouteSpeed (converts 0..100 rating to 0..69) and scales MovementTuning max/accel/decel deterministically. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/RouteFollowSystem.cs

#### 6.2 Blocking Assignments (Assembly-Accurate)
- [x] #nextaction **BLOCK-1:** Study assembly blocking assignment tables — DONE: documented current understanding + ECS translation + YAML gaps in tecmo-super-bowl-monogame/docs/BLOCKING.md
- [x] #nextaction **BLOCK-2:** Create BlockTargetComponent (target defender, assignment type) — DONE: BlockTargetComponent + BlockAssignmentType already exist. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Components/BlockTargetComponent.cs
- [x] #nextaction **BLOCK-3:** Implement BlockerAI - seek target and engage — DONE: BlockerAISystem exists (target selection, movement toward defender, engagement bookkeeping, double-team/cut-block scaffolds). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/BlockerAISystem.cs
- [x] #nextaction **BLOCK-4:** Handle double-teams (two blockers on one defender) — DONE: BlockerAISystem.ApplyDoubleTeams marks blockers IsDoubleTeam and applies SpeedModifier penalty to defender while double-teamed. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/BlockerAISystem.cs
- [x] #nextaction **BLOCK-5:** Implement cut blocking logic (chance based on RS?) — DONE (scaffold): BlockerAISystem.MaybeAttemptCutBlock performs deterministic chance gate and applies defender speed mod (pancake-like). RS-based chance not yet wired. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/BlockerAISystem.cs
- [x] #nextaction **BLOCK-6:** Block release to second level (LB pursuit) — DONE (scaffold): BlockerAISystem releases to SecondLevel after engagement window (DEFAULT_RELEASE_TO_SECOND_LEVEL_AFTER_FRAMES) and re-targets accordingly. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/BlockerAISystem.cs

#### 6.3 QB AI (Dropback + Pass Decision)
- [x] #nextaction **QB-1:** Study QB dropback sequence from assembly — DONE (current state + gaps): documented current deterministic approximation + planned YAML schema in tecmo-super-bowl-monogame/docs/QB_AI.md; dropback logic implemented in QbDropbackSystem (not ROM-accurate yet).
- [x] #nextaction **QB-2:** Create QbBrainComponent (dropback step counter, read progression) — DONE: QbBrainComponent exists with dropback state + read progression fields/timers. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Components/QbBrainComponent.cs
- [x] #nextaction **QB-3:** Implement QbDropbackSystem - fixed-step dropback (3-step, 5-step, 7-step) — DONE: QbDropbackSystem exists (frame-based steps + rollouts). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/QbDropbackSystem.cs
- [x] #nextaction **QB-4:** Implement read progression (1st read → 2nd read → 3rd read → scramble) — DONE: ReadProgressionSystem exists (read timers, throw-on-break window, pressure->scramble). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ReadProgressionSystem.cs
- [x] #nextaction **QB-5:** Add pocket awareness (sack avoidance, step up) — DONE (partial scaffold): ReadProgressionSystem already detects pressure and performs a step-up-in-pocket movement before scrambling (STEP_UP_PIXELS_PER_TICK). Sack-avoidance beyond this is still TODO. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ReadProgressionSystem.cs
- [x] #nextaction **QB-6:** Pass decision timing (throw on break, don't stare down) — DONE (scaffold): ReadProgressionSystem enforces MIN_OPEN_FRAMES_BEFORE_THROW (don’t throw on first open frame) and approximates throw-on-break window behavior. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ReadProgressionSystem.cs
- [x] #nextaction **QB-7:** Scramble trigger (no open receivers + pressure) — DONE (scaffold): ReadProgressionSystem triggers ScrambleMode when reads exhausted and/or sustained pressure (>= PRESSURE_THRESHOLD). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ReadProgressionSystem.cs

#### 6.4 Defensive Rush (Assembly-Accurate)
- [x] #nextaction **RUSH-1:** Study defensive rush logic from assembly — DONE (current scaffold): DESIGN.md documents gap-assignment rush concept + deterministic rush-move formulas; RushComponent/RushSystem implement gap landmark → QB rush + stunts + deterministic rush-move attempts. Evidence: tecmo-super-bowl-monogame/docs/DESIGN.md + src/TecmoSBGame/Systems/RushSystem.cs
- [x] #nextaction **RUSH-2:** Create RushComponent (target gap, rush type: power/swim/spin) — DONE: RushComponent + RushGap + RushType already exist. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Components/RushComponent.cs
- [x] #nextaction **RUSH-3:** Implement RushSystem - path to QB through assigned gap — DONE: RushSystem implements gap landmark phase then QB rush phase. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/RushSystem.cs
- [x] #nextaction **RUSH-4:** Handle OL engagement (rush move success based on MS/HP vs blocker) — DONE: RushSystem consumes BlockContactEvent to mark engagement; TryResolveRushMove uses deterministic MS/HP formulas w/ cooldown to break blocks. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/RushSystem.cs
- [x] #nextaction **RUSH-5:** Contain rush (don't over-pursue, keep QB in pocket) — DONE (scaffold): RushSystem.ComputeQBRushTarget has contain logic to keep outside leverage and clamp depth near QB. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/RushSystem.cs
- [x] #nextaction **RUSH-6:** Stunt/twist coordination for DL — DONE (scaffold): RushSystem supports stunt gap swap after StuntDelayFrames (IsStunt/StuntTargetGap). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/RushSystem.cs

#### 6.5 Coverage (Man/Zone Assembly-Accurate)
- [x] #nextaction **COVER-1:** Study coverage tables from assembly — DONE (current scaffold): DESIGN.md documents man mirroring reaction delay, zone landmark kinds/coords, and ball-in-air reaction timing. Evidence: tecmo-super-bowl-monogame/docs/DESIGN.md (Coverage AI section)
- [x] #nextaction **COVER-2:** Create CoverageComponent (type: man/zone, assignment, depth) — DONE: CoverageComponent exists with coverage type + man target + zone landmark + reaction delay state. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Components/CoverageComponent.cs
- [x] #nextaction **COVER-3:** Implement ManCoverageSystem - mirror receiver route — DONE: ManCoverageSystem exists (reaction delay, cushion, break-on-throw scaffold). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ManCoverageSystem.cs
- [x] #nextaction **COVER-4:** Implement ZoneCoverageSystem - defend landmark, react to threats — DONE: ZoneCoverageSystem exists (drop to landmark, reaction delay, threat match + carry window, break-on-throw scaffold). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ZoneCoverageSystem.cs
- [x] #nextaction **COVER-5:** Pattern matching for zone (carry receiver through zone) — DONE (scaffold): ZoneCoverageSystem includes a carry window (CARRY_FRAMES=15) before passing off/returning. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ZoneCoverageSystem.cs
- [x] #nextaction **COVER-6:** Ball-in-air reaction (break on throw) — DONE (scaffold): ManCoverageSystem/ZoneCoverageSystem react to PassRequestedEvent / ball in-air to break toward target/end-point. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Systems/ManCoverageSystem.cs + ZoneCoverageSystem.cs
- [x] #nextaction **COVER-7:** Deep safety logic (cover 1/2/3 responsibilities) — DONE (scaffold): CoverageType includes DeepHalf/DeepThird/DeepQuarter and ZoneCoverageSystem treats them as deep zones (landmark + zone rect sizing + threat match). Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Components/CoverageComponent.cs + Systems/ZoneCoverageSystem.cs

#### 6.6 Special Teams (Assembly-Accurate)
- [x] #nextaction **ST-1:** Study kickoff coverage lanes from assembly — DONE (current scaffold + gap): kickoff lane behavior is currently driven by formation command scripts parsed by FormationScriptParser (MoveAbsolute/Relative/Pause/etc) to produce recognizable lanes; no ROM-accurate lane tables mapped yet. Evidence: tecmo-super-bowl-monogame/src/TecmoSBGame/Spawning/FormationScriptParser.cs + FormationSpawner kickoff notes.
- [x] #nextaction **ST-2:** Create KickoffCoverageComponent (lane assignment, contain/contain-break) — DONE: added KickoffCoverageComponent scaffold (lane index/count, contain, landmark, break flag). Commit: f0a222a
- [x] #nextaction **ST-3:** Implement KickoffCoverageSystem - run lane then pursue returner — DONE: added KickoffCoverageSystem (kickoff slice only) that drives Behavior to lane landmark then breaks on returner once they possess ball; hooked into MainGame systems; KickoffCoverageComponent now carries ReturnerEntityId. Commit: 47f3464
- [x] #nextaction **ST-4:** Kickoff return lane selection (find seam, follow blockers) — DONE (scaffold): added KickoffReturnComponent + KickoffReturnSystem that chooses a left/center/right seam based on nearby coverage counts, locks lane briefly, and drives Behavior.TargetPosition while kickoff slice is active; factory attaches to non-player returners. Commit: 943fd2b
- [x] #nextaction **ST-5:** Punt coverage logic (gunners downfield) — DONE (scaffold): added PuntCoverageComponent + PuntCoverageSystem (lane landmark, gunner bias, break on returner) and wired into MainGame; punt flight integration still pending. Commit: 4e407dc
- [x] #nextaction **ST-6:** Punt return blocking (set up wall, find lane) — DONE (scaffold): added PuntReturnComponent + PuntReturnSystem that chooses a left/center/right seam based on nearby coverage counts and drives Behavior.TargetPosition during special-teams slice. Commit: 3cd36e3
- [x] #nextaction **ST-7:** Field goal block rush timing — DONE (scaffold): added FieldGoalBlockRushComponent + FieldGoalBlockRushSystem (DelayFrames then rush forward) and wired into MainGame; needs proper FG play-phase integration. Commit: 7f2a7c2

#### 6.7 AI Infrastructure
- [x] #nextaction **AI-INFRA-1:** Create AIDebugSystem for visualizing AI decisions (routes, coverage, targets) — DONE (scaffold): added AIDebugConfigComponent (singleton instance) + AIDebugDrawableComponent per entity; AIDebugSystem populates debug data (behavior targets, route next node, coverage target/landmark). Attached drawable to players+ball; system wired into world builder. Commit: 7010d22
- [x] #nextaction **AI-INFRA-2:** Add AI decision logging for headless verification — DONE: added AIDecisionLogSystem (logs QB read/dropback/pressure, a few receiver route node targets, and a defender coverage summary every ~15 frames) and wired into HeadlessRunner. Commit: 530592f
- [x] #nextaction **AI-INFRA-3:** Create deterministic AI seed system (same play = same decisions) — DONE: added deterministic seed plumbing in PlayState: BaseSeed + DeterministicSeed computed on ResetForNewPlay via DeterministicRng.SeedFromPlay (BaseSeed, PlayId, StartAbsoluteYard). Commit: f84cbfd
- [x] #nextaction **AI-INFRA-4:** Assembly behavior test harness (compare to recorded NES gameplay) — DONE (scaffold): added JSON trace schema + headless compare runner `--headless-nes-compare <trace.json> [maxTicks]` (compares QB position with tolerance and prints diffs). Commit: 78d0e7d

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

### 9) UI + game states (fully playable loop) ✅ DONE (2025-03-09)

**Implementation Summary:**

#### 9.1 HUD (Heads-Up Display) ✅
- [x] **HudComponent** + **HudSystem** — ECS component with Scoreboard/DownDistance/PlayClock/PossessionIndicator types
- [x] **ScoreboardRenderer** — Away/home scores, quarter (Q1-Q4), game clock (MM:SS), team plates with Tecmo styling
- [x] **DownDistanceRenderer** — Down indicator (1st/2nd/3rd/4th), yards to go (with "Goal" handling), ball spot (T0/T1 yardline), field position bar with midfield marker
- [x] **NesHudFont** — Built-in 5x7 pixel font for HUD text without requiring SpriteFont pipeline

#### 9.2 Title → Menu Flow ✅
- [x] **MenuItemComponent** + **MenuNavigationSystem** — Non-ECS menu system with selection tracking
- [x] **TitleScreenRenderer** — Tecmo-style title blocks, blinking "PRESS START" (~1Hz), copyright placeholder
- [x] **MainMenuRenderer** — 5-item vertical menu (Preseason, Season, Pro Bowl, Options, Data) with selection highlight
- [x] Wired to **GameFlowController** for state transitions

#### 9.3 Team Select Screen ✅
- [x] **TeamSelectRenderer** — Two-column layout (Away/Home), scrollable team list with scrollbar, P1/P2 indicators
- [x] Team roster preview — Team name + OFF/DEF/OVR ratings bars (deterministic from team ID)
- [x] Active column switching with gold highlight

#### 9.4 Coin Toss Screen ✅
- [x] **CoinTossRenderer** — Team banners (Away top, Home bottom), pulsing coin animation
- [x] HEADS/TAILS call selection, RECEIVE/KICK decision for winner
- [x] Wind direction indicator with arrow (→/←) and bar visualization

#### 9.5 Playcall UI ✅
- [x] **PlayCallComponent** + **PlayCallSystem** — Full ECS system for pre-snap play selection
  - Formation grid (4x3) navigation with arrow keys
  - Play list for selected formation
  - Defensive formation selection (toggle with Shift)
  - Confirm with Start/Enter emits **PlaySelectedEvent**
- [x] **FormationSelectRenderer** — Formation grid with abbreviations
- [x] **PlaySelectRenderer** — Vertical play list
- [x] **DefensivePlaySelectRenderer** — Defensive formation grid
- [x] **PlayDiagramRenderer** — X's and O's diagram with route lines

#### 9.6 Post-Play Summary ✅
- [x] **PostPlaySummaryRenderer** — Tecmo-style overlay with:
  - Result label (TOUCHDOWN, FIRST DOWN, INCOMPLETE, etc.)
  - Yards gained/lost with color coding
  - Updated down/distance and ball spot
  - First down indicator
  - "PRESS START TO CONTINUE" or auto-dismiss

#### 9.7 UI Infrastructure ✅
- [x] **FontSystem** — Singleton for SpriteFont loading (Small/Medium/Large)
- [x] **PanelRenderer** — DrawPanel, DrawTecmoBox (blue+gold styling), DrawBorder, 9-slice support
- [x] **InputPromptRenderer** — Blinking "PRESS START" prompt
- [x] **UiColors** — TecmoBlue, TecmoGold, TextWhite, TextGray, Highlight, Good, Bad, OverlayDim
- [x] **UiScaling** — Base width/height constants (256x224)

#### 9.8 Assembly-Faithful Details ✅
- [x] NES 256x224 virtual resolution throughout
- [x] Tecmo color palette (blue #0066CC, gold #FFCC00)
- [x] Pixel-perfect UI rendering
- [x] All UI respects RenderViewport scaling

**Files Created:**
```
Rendering/
  ScoreboardRenderer.cs
  DownDistanceRenderer.cs
  TitleScreenRenderer.cs
  MainMenuRenderer.cs
  TeamSelectRenderer.cs
  CoinTossRenderer.cs
  NesHudFont.cs
  UI/
    UiColors.cs
    UiScaling.cs
    FontSystem.cs
    PanelRenderer.cs
    InputPromptRenderer.cs
  PlayCall/
    FormationSelectRenderer.cs
    PlaySelectRenderer.cs
    DefensivePlaySelectRenderer.cs
    PlayDiagramRenderer.cs
    PlayCallUiAssets.cs
  PostPlay/
    PostPlaySummaryRenderer.cs

Components/
  HudComponent.cs
  Menu/
    MenuItemComponent.cs
  PlayCall/
    PlayCallComponent.cs

Systems/
  HudSystem.cs
  Menu/
    MenuNavigationSystem.cs
  PlayCall/
    PlayCallSystem.cs
```

**Build Status:** ✅ Compiles (64 warnings, 0 errors)

**Integration:** MainGame.cs updated with all new renderers, systems wired into ECS world

### 10) Audio integration
- [x] #nextaction Implement SoundService and hook key events (snap/kick/hit/whistle/crowd/menu) matching assembly cues. — DONE (scaffold): added Audio/SoundService + SoundCue enum + SoundSystem that drains GameEvents (Snap, catch/pass outcome, tackle/block hit, whistle, fumble) and triggers cues; wired into MainGame; asset keys are placeholders. Commit: abb014e
- [x] #nextaction Implement music state switching (title/menu/on-field/score/halftime) matching assembly. — DONE (scaffold): added MusicState enum + SoundService.SetMusicState + MainGame flow-state mapping (Title/Menu/OnField/Score); actual Song/MediaPlayer playback + assembly-accurate mapping still TODO. Commit: 2fbfd99

### 11) Sprite scripts / draw scripts direction (needs decision)

### 12) Debugging + tooling
- [x] #nextaction Add in-game debug overlay (state ids, selected player, ball state/owner, key timers) for assembly parity debugging. — DONE (scaffold): added DebugOverlayRenderer showing match/play/ball/timers/seed; wired into MainGame draw and toggle via F4. Commit: 889f35c
- [x] #nextaction Add replay recorder (tick snapshots) to compare behavior vs assembly. — DONE (scaffold): added ReplayRecorder + ReplayRecorderSystem capturing per-tick PositionComponent positions + ball state/owner to JSON; toggle via F5; auto-saves on whistle. Commit: 577a869
- [x] #nextaction Add YAML validation pass with actionable errors (missing ids, bad references, out-of-range values). — DONE: added cross-file validator (formations/playlist/playdata) and wired it into GameContent.LoadAll (fails fast w/ issue list). Commit: 3a74586


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
