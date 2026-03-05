using GameEvents;
using Interfaces;

namespace ContinuousEffects;

public abstract class MadnessEffect : ReplacementEffect
{
    protected MadnessEffect()
    {
    }

    protected MadnessEffect(MadnessEffect effect) : base(effect)
    {
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CardMovedEvent e && e.Source == ZoneType.Hand && e.Destination == ZoneType.Graveyard && Source.Id == e.CardInSourceZone;
    }
}
