using Engine;
using Engine.GameEvents;
using Interfaces;

namespace ContinuousEffects;

public abstract class DestructionReplacementOptionallyToHandEffect : DestructionReplacementEffect
{
    public DestructionReplacementOptionallyToHandEffect() : base()
    {
    }

    public DestructionReplacementOptionallyToHandEffect(DestructionReplacementOptionallyToHandEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.Hand
            };
        }
        else
        {
            return gameEvent;
        }
    }
}
