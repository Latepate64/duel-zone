using Interfaces;
using Interfaces.Zones;

namespace Cards;

public class ControllerControlsAnyOtherCreaturesCondition : ICondition
{
    private readonly IBattleZone battleZone;
    private readonly ICardFilter filter;

    public ControllerControlsAnyOtherCreaturesCondition(IBattleZone battleZone, ICardFilter filter)
    {
        this.battleZone = battleZone;
        this.filter = filter;
    }

    private ControllerControlsAnyOtherCreaturesCondition(
        ControllerControlsAnyOtherCreaturesCondition condition)
    {
    }

    public ICondition Copy()
    {
        return new ControllerControlsAnyOtherCreaturesCondition(this);
    }

    public bool IsMet(ICreature creature)
    {
        return battleZone.HasOtherCreaturesControllerByPlayer(creature, filter);
    }
}