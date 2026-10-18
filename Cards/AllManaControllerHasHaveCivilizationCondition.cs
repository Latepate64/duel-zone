using Interfaces;

namespace Cards;

public class AllManaControllerHasHaveCivilizationCondition : ICondition
{
    private readonly Civilization civilization;

    public AllManaControllerHasHaveCivilizationCondition(Civilization civilization)
    {
        this.civilization = civilization;
    }

    private AllManaControllerHasHaveCivilizationCondition(
        AllManaControllerHasHaveCivilizationCondition condition)
    {
        civilization = condition.civilization;
    }

    public ICondition Copy()
    {
        return new AllManaControllerHasHaveCivilizationCondition(this);
    }

    public bool IsMet(ICreature creature)
    {
        return creature.OwnerV2.ManaZone.AreAllCivilizationCards(civilization);
    }
}