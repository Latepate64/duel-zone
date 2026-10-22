using Interfaces;

namespace Cards;

public class ControllerHasNoHandCardsCondition : ICondition
{
    public ICondition Copy()
    {
        return new ControllerHasNoHandCardsCondition();
    }

    public bool IsMet(ICreature creature)
    {
        return !creature.OwnerV2.Hand.HasCards;
    }
}