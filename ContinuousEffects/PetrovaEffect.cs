using GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class PetrovaEffect : ReplacementEffect
{
    public PetrovaEffect()
    {
    }

    public PetrovaEffect(PetrovaEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        var race = Controller.ChooseRace(ToString(), Race.MechaDelSol);
        return new PetrovaEvent(gameEvent as CardMovedEvent, race);
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is ICardMovedEvent e && Source.Id == e.CardInSourceZone
            && e.Destination == ZoneType.BattleZone;
    }

    public override IContinuousEffect Copy()
    {
        return new PetrovaEffect(this);
    }

    public override string ToString()
    {
        return "When you put this creature into the battle zone, choose a race other than Mecha del Sol. Each creature of that race gets +4000 power.";
    }
}
