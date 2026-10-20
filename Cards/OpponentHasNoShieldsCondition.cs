using Interfaces;

namespace ContinuousEffects.CannotAttack;

public class OpponentHasNoShieldsCondition : ICondition
{
    public ICondition Copy()
    {
        return new OpponentHasNoShieldsCondition();
    }

    public bool IsMet(ICreature creature)
    {
        return !creature.OwnerV2.Opponent.ShieldZone.HasCards;
    }
}