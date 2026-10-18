using Interfaces;

namespace Cards;

public class ControllerHasNoShieldsCondition : ICondition
{
    public bool IsMet(ICreature creature)
    {
        return !creature.OwnerV2.ShieldZone.HasCards;
    }

    public ICondition Copy()
    {
        return new ControllerHasNoShieldsCondition();
    }
}