using Engine;
using Engine.GameEvents;
using Interfaces;

namespace ContinuousEffects;

public abstract class WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
{
    protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
    {
    }

    protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.ManaZone
        };
    }
}
