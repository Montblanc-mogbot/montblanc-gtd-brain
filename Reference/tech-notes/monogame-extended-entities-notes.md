# MonoGame.Extended Entities (ECS) — notes (for TecmoSB)

Source: <https://www.monogameextended.net/docs/features/entities/>

## What it is
- **MonoGame.Extended.Entities** is a **high-performance, Artemis-inspired ECS**.
- ECS is composed of **Components** (data), **Entities** (IDs + component composition), and **Systems** (logic that runs in `Update`/`Draw`).

## Key concepts
### Components
- Components are **data-only** objects (typically lightweight classes; “pure ECS” often uses structs).
- Avoid putting gameplay logic inside components.
- Typical component examples:
  - Position/transform (e.g., `Transform2` / `Vector2 Position`)
  - Sprite/rendering (e.g., sprite/texture region)
  - Health, shield, timers, etc.
- **Design goal:** decompose common features into reusable components so systems can operate on broad sets of entities.

**Important limitation (from docs):**
- A `ComponentMapper` can only return up to **32 components**. Architect component breakdown accordingly.

### Entities
- Entities are identified by an **ID** and are just a **composition of components**.
- In MonoGame.Extended you create entities with:
  - `var entity = world.CreateEntity();`
- Entity IDs are only valid while the entity is alive (IDs may be recycled).

### Systems
- Systems contain the logic and run during the game loop.
- Base system types mentioned:
  - `UpdateSystem` / `DrawSystem`
  - `EntityUpdateSystem` / `EntityDrawSystem`
  - `EntityProcessingSystem`
  - Or implement `IUpdateSystem` + `IDrawSystem` for combined behavior.

## Typical render system shape (important for our rendering refactor)
### Filtering with Aspects
- Entity systems filter the entities they process via an **Aspect**.
- Key aspect APIs:
  - `Aspect.All(A, B)` → must have *all* components
  - `Aspect.One(C, D)` → must have *any* (C or D)
  - `Aspect.Exclude(E, F)` → exclude entities with any of these
- Aspects can be chained:
  - `Aspect.All(A, B).One(C, D).Exclude(E)`

### RenderSystem example (docs pattern)
- A typical renderer wants entities with **Sprite + Transform**:

```csharp
public class RenderSystem : EntityDrawSystem
{
    public RenderSystem(GraphicsDevice graphicsDevice)
        : base(Aspect.All(typeof(Sprite), typeof(Transform2)))
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = new SpriteBatch(graphicsDevice);
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        foreach (var entityId in ActiveEntities)
        {
            // draw entity using mapped components
        }
        _spriteBatch.End();
    }
}
```

Notes for our codebase:
- In our game, **`MainGame.Draw()` already calls `SpriteBatch.Begin/End`**, so our ECS draw systems should follow the pattern we already documented in `RenderingSystem`: *do not call Begin/End inside the ECS draw system*.

## Component access: mappers (preferred)
### ComponentMapper pattern
- Docs recommend using `ComponentMapper<T>` for speed (near direct access to underlying storage).
- Obtain mappers in `Initialize(IComponentMapperService mapperService)`:

```csharp
private ComponentMapper<Transform2> _transformMapper;
private ComponentMapper<Sprite> _spriteMapper;

public override void Initialize(IComponentMapperService mapperService)
{
    _transformMapper = mapperService.GetMapper<Transform2>();
    _spriteMapper = mapperService.GetMapper<Sprite>();
}
```

Then in `Draw`/`Update`:

```csharp
var transform = _transformMapper.Get(entityId);
var sprite = _spriteMapper.Get(entityId);
```

### Modifying entities via mappers
- `Put(entityId, component)` can **add or replace** a component of that type.

### Getting entities from components (recommended)
- Prefer `TryGet(...)` when retrieving to avoid explicit `Has`/null checks.

## World setup / lifecycle (docs)
### WorldBuilder
- Create the ECS world by adding systems in a specific order (ordering matters):

```csharp
_world = new WorldBuilder()
    .AddSystem(new PlayerSystem())
    .AddSystem(new RenderSystem(GraphicsDevice))
    .Build();
```

- You then call `_world.Update(gameTime)` and `_world.Draw(gameTime)` from your game loop.

### Entity lifecycle summary
1. `CreateEntity` queues creation
2. Next world update activates queued entities
3. Component changes trigger `EntityChanged`
4. `DestroyEntity` queues removal
5. Next update removes + returns entity to pool

## Practical takeaway for TecmoSB rendering
- Rendering should be implemented as an `EntityDrawSystem` filtered by an Aspect such as:
  - Position/Transform + Sprite
- Access component data through `ComponentMapper<>`.
- Keep GPU resources (textures, sprite sheets) **out of components** if we want decoupling;
  - Instead store identifiers/keys in `SpriteComponent` (e.g., `SpriteId`, `AnimId`, `Tint`, `Flip`) and resolve via a centralized render resource/atlas.
- Avoid per-frame allocations in Draw (especially `new Texture2D(...)` inside Draw loops).
