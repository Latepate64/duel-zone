using Engine;
using Engine.GameEvents;
using Interfaces;

namespace ContinuousEffects;

public abstract class WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : DestructionReplacementEffect
{
    protected WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
    {
    }

    protected WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect() : base()
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.Hand
        };
    }
}