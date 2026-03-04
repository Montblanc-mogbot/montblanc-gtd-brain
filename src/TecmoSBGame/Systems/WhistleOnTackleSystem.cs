using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using TecmoSBGame.Events;

namespace TecmoSBGame.Systems;

/// <summary>
/// Example decoupled consumer/producer: turns a tackle into a whistle.
///
/// This system demonstrates how game logic can react to events without
/// hard-wiring dependencies between gameplay systems.
/// </summary>
public sealed class WhistleOnTackleSystem : EntityUpdateSystem
{
    private readonly GameEvents _events;

    public WhistleOnTackleSystem(GameEvents events) : base(Aspect.Empty())
    {
        _events = events;
    }

    public override void Update(GameTime gameTime)
    {
        _events.Drain<TackleEvent>(_ =>
        {
            _events.Publish(new WhistleEvent("tackle"));
        });
    }
}