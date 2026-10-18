using Interfaces;

namespace Cards.DM03;

public class AllManaPlayerHasHaveCivilizationCondition : ICondition
{
    private readonly Civilization civilization;

    public AllManaPlayerHasHaveCivilizationCondition(Civilization civilization)
    {
        this.civilization = civilization;
    }

    private AllManaPlayerHasHaveCivilizationCondition(
        AllManaPlayerHasHaveCivilizationCondition condition)
    {
        civilization = condition.civilization;
    }

    public ICondition Copy()
    {
        return new AllManaPlayerHasHaveCivilizationCondition(this);
    }

    public bool IsMet(IPlayerV2 player)
    {
        return player.ManaZone.AreAllCivilizationCards(civilization);
    }
}