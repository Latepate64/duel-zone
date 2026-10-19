using Interfaces;

namespace Cards;

public class CreatureIsTappedCondition : ICondition
{
    public ICondition Copy()
    {
        return new CreatureIsTappedCondition();
    }

    public bool IsMet(ICreature creature)
    {
        return creature.Tapped;
    }
}