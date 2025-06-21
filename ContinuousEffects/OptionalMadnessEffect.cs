using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class OptionalMadnessEffect : MadnessEffect
{
    public OptionalMadnessEffect()
    {
    }

    public OptionalMadnessEffect(OptionalMadnessEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.BattleZone
            };
        }
        else
        {
            return gameEvent;
        }
    }

    public override IContinuousEffect Copy()
    {
        return new OptionalMadnessEffect(this);
    }

    public override string ToString()
    {
        return "When this creature would be discarded from your hand during your opponent's turn, you may put it into the battle zone instead.";
    }
}
