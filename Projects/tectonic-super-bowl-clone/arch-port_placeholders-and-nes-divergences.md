# Arch port (SimArch) — Placeholder inventory + NES divergences (from today’s refactor thread)

Scope: this is a *triage list* of (a) placeholder/stub/scaffold programs introduced during the MGE→Arch refactor and (b) NES divergences explicitly observed/mentioned during the thread.

Source of truth for placeholder detection: `rg -n "TODO:|scaffold|deterministic no-op|placeholder" src/TecmoSBGame/SimArch` plus notes from the thread.

---

## 1) Placeholder / scaffold programs (grouped)

### A. Headless + NES trace compare
- `src/TecmoSBGame/SimArch/Headless/NesTraceCompareRunner.cs`
  - Placeholder: does **not** diff trace vs sim yet; it parses the trace and just runs the Arch scenario.
  - TODO noted in file: “true diffing once snapshot parity fields are stabilized.”

- `src/TecmoSBGame/SimArch/Headless/NesTraceModels.cs`
  - Models only (no placeholder logic).

- `src/TecmoSBGame/SimArch/Headless/CoverageScenarioDriverSystem.cs`
  - Placeholder: no scenario logic yet.

- `src/TecmoSBGame/SimArch/Headless/HeadlessContactSeederSystem.cs`
  - Placeholder: no seeding logic yet.

- `src/TecmoSBGame/SimArch/Headless/HeadlessRunner.cs`
  - Compatibility wrapper: routes to `SimArchHeadless.RunTwoPlaysScenario`.

### B. Spawning / scripting compilation
- `src/TecmoSBGame/SimArch/Spawning/FormationScriptParser.cs`
  - Placeholder: currently emits deterministic `NOP` ops for formation command strings.

- `src/TecmoSBGame/SimArch/Spawning/PlayDataScriptCompiler.cs`
  - Partial: compiles by id via `PlayScriptRegistry.CompileReaction`.
  - Limitation: only whatever opcodes the PlayScriptRegistry currently supports.

- `src/TecmoSBGame/SimArch/Spawning/PlayScriptCompiler.cs`
  - Wrapper over the PlayScriptRegistry compiler.

- `src/TecmoSBGame/SimArch/PlayScripts/PlayScriptRegistry.cs`
  - Partial: only a subset of PlayData commands compiled.

- `src/TecmoSBGame/SimArch/Spawning/FormationSpawner.cs`
  - Placeholder aspect: defense spawn is explicitly described as placeholder; many defensive roles are deterministic stand-ins.

- `src/TecmoSBGame/SimArch/Spawning/PlaySpawner.Slots.cs`
  - Placeholder mapping: deterministic mapping of placeholder defense entities to authored defensive slot keys.

### C. Rules/state / loop machines
- `src/TecmoSBGame/SimArch/State/MatchState.cs`
  - Marked as scaffold; rules are simplified and intended to be refined later.

- `src/TecmoSBGame/SimArch/State/PlayState.cs`
  - Marked as scaffold; contains minimal phase + whistle + play result.

- `src/TecmoSBGame/SimArch/Systems/DownDistanceSystem.cs`
  - Marked as scaffold; conservative yard/spotting behavior.

- `src/TecmoSBGame/SimArch/Systems/LoopMachineSystem.cs`
  - Placeholder: does not yet wire YAML loop machines.

- `src/TecmoSBGame/SimArch/Systems/GameStateSystem.cs`
  - Placeholder: does not orchestrate full pre-snap/in-play/post-play transitions yet.

- `src/TecmoSBGame/SimArch/Systems/PlayExecutionSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/PlayEndSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/PlayResultResolver.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/NextPlayResetSystem.cs`
  - Placeholder.

### D. Coverage / rush / blocking
- `src/TecmoSBGame/SimArch/Systems/CoverageSystem.cs`
  - Explicitly described as scaffold.

- `src/TecmoSBGame/SimArch/Systems/ManCoverageSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/ZoneCoverageSystem.cs`
  - Wrapper around `CoverageSystem` (created for 1:1 naming parity).

- `src/TecmoSBGame/SimArch/Systems/DefensiveRushSystem.cs`
  - Explicitly described as scaffold.

- `src/TecmoSBGame/SimArch/Systems/BlockerAiSystem.cs`
  - Explicitly described as scaffold.

- `src/TecmoSBGame/SimArch/Systems/EngagementSystem.cs`
  - Scaffolding for later resolution/animations.

### E. Tackles / fumbles / loose ball
- `src/TecmoSBGame/SimArch/Systems/TackleResolutionSystem.cs`
  - Explicitly described as deterministic scaffold (not Tecmo-perfect).

- `src/TecmoSBGame/SimArch/Systems/TackleInterruptSystem.cs`
  - Scaffolding.

- `src/TecmoSBGame/SimArch/Systems/FumbleOnTackleWhistleSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/FumbleResolutionSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/LooseBallPickupSystem.cs`
  - Placeholder.

### F. Input / UI flow
- `src/TecmoSBGame/SimArch/Systems/InputSystem.cs`
  - Placeholder (MainGameArch is currently pushing input straight into `Sim.SetInput`).

- `src/TecmoSBGame/SimArch/Input/InputManager.cs`
  - Functional input router, but game wiring is incomplete (context switching not yet used everywhere).

- `src/TecmoSBGame/SimArch/Systems/PlayCall/PlayCallSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/PostPlayContinueInputSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/Menu/MenuNavigationSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/HudSystem.cs`
  - Placeholder.

### G. Rendering / camera / animation
- `src/TecmoSBGame/SimArch/Systems/RenderingSystem.cs`
  - Parity placeholder (MainGameArch renders directly from SimSnapshot).

- `src/TecmoSBGame/SimArch/Systems/CameraSystem.cs`
  - Implemented as simple follow; NES-feel tuning pending.

- `src/TecmoSBGame/SimArch/Systems/AnimationSystem.cs`
  - Implemented; clip selection is still simplistic (real sprite timing/selection pending).

### H. Special teams
- `src/TecmoSBGame/SimArch/Components/FieldGoalBlockRush.cs`
  - Component scaffold.

- `src/TecmoSBGame/SimArch/Systems/FieldGoalBlockRushSystem.cs`
  - Basic timing scaffold.

- `src/TecmoSBGame/SimArch/Systems/PuntCoverageSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/PuntReturnSystem.cs`
  - Placeholder.

### I. Replay / sound
- `src/TecmoSBGame/SimArch/Systems/ReplayRecorderSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Replay/ReplayRecorder.cs`
  - Writes JSON, but capture isn’t wired end-to-end yet.

- `src/TecmoSBGame/SimArch/Systems/SoundSystem.cs`
  - Placeholder.

### J. Debug / logging
- `src/TecmoSBGame/SimArch/Systems/AIDebugSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/AIDecisionLogSystem.cs`
  - Placeholder.

- `src/TecmoSBGame/SimArch/Systems/ContactDebugLogSystem.cs`
  - Implemented (event drain + log), but only useful once those events are consistently produced.

### K. Compatibility stubs
- `src/TecmoSBGame/SimArch/MainGameCompat.cs`
  - Placeholder compat stub created so the “archive ledger” has a 1:1 target for `ArchiveMge/MainGame.cs`.

- `src/TecmoSBGame/SimArch/SimMode.cs`
  - Compat enum (Arch-only now).

---

## 2) NES divergences (explicitly mentioned/observed in the thread)

These are *not exhaustive*; they are the divergences we explicitly called out while porting.

1) **PlayScript opcode coverage is incomplete**
   - Many PlayData commands are not compiled/executed yet; this will diverge from both MGE and NES until completed.

2) **Down/distance + spotting + rules are conservative scaffolds**
   - `DownDistanceSystem`, `MatchState`, `PlayState`, and the in-sim logic around end-of-play currently avoid large state jumps and are not Tecmo-accurate.

3) **Tackle resolution is explicitly “not Tecmo-perfect yet”**
   - `TackleResolutionSystem` is a deterministic scaffold; outcome tables/timing will differ from NES.

4) **Camera behavior / feel not tuned to NES**
   - Camera deadzone/scrolling rules are simplified; not parity.

5) **Animation timing/selection is simplistic**
   - Clip selection is derived from simple heuristics; not parity with NES animation timing.

6) **Coverage / rush / blocking AI are scaffolds or incomplete**
   - Systems exist, but behavior rules (reaction delays, leverage, rush moves) are not ROM-accurate.

7) **Kickoff/punt/FG special teams logic incomplete**
   - Components/systems exist but are not fully implemented or parity.

8) **NES trace compare runner is scaffolded**
   - Trace parsing works; real diffing not implemented until snapshot parity stabilizes.

---

## 3) Suggested next actions (to remove placeholders)

- Implement `FormationScriptParser` grammar + `FormationScriptSystem` interpreter.
- Expand `PlayScriptRegistry` opcode coverage until all PlayData commands used in banks are supported.
- Replace placeholder defense formation spawn with YAML-driven defensive formations.
- Finish rules pipeline:
  - `GameStateSystem` orchestration
  - `PlayExecutionSystem` + `PlayEndSystem` + `PlayResultResolver`
  - accurate spotting + clock
- Finish fumbles/loose ball pipeline.
- Wire replay capture to snapshot and stabilize the JSON schema.
- Implement NES trace diffing once snapshot parity fields exist.
