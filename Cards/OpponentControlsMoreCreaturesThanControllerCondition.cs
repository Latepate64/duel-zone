using Interfaces;
using Interfaces.Zones;

namespace Cards;

public class OpponentControlsMoreCreaturesThanControllerCondition : ICondition
{
    private readonly IBattleZone battleZone;
    private readonly ICardFilter filter;

    public OpponentControlsMoreCreaturesThanControllerCondition(
        IBattleZone battleZone, ICardFilter filter)
    {
        this.battleZone = battleZone;
        this.filter = filter;
    }

    private OpponentControlsMoreCreaturesThanControllerCondition(
        OpponentControlsMoreCreaturesThanControllerCondition condition)
    {
        battleZone = condition.battleZone;
        filter = condition.filter.Copy();
    }

    public ICondition Copy()
    {
        return new OpponentControlsMoreCreaturesThanControllerCondition(this);
    }

    public bool IsMet(ICreature creature)
    {
        var numberOfOpponentsCreatures = battleZone.GetNumberOfCreaturesControllerByPlayer(
            creature.OwnerV2.Opponent, filter);
        var numberOfOwnCreatures = battleZone.GetNumberOfCreaturesControllerByPlayer(
            creature.OwnerV2, filter);
        return numberOfOpponentsCreatures > numberOfOwnCreatures;
    }
}