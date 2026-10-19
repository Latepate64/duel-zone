using Interfaces;
using Interfaces.Zones;

namespace Cards;

public class ControllerControlsNoOtherCreaturesCondition : ICondition
{
    private readonly IBattleZone battleZone;
    private readonly ICardFilter filter;

    public ControllerControlsNoOtherCreaturesCondition(IBattleZone battleZone, ICardFilter filter)
    {
        this.battleZone = battleZone;
        this.filter = filter;
    }

    private ControllerControlsNoOtherCreaturesCondition(
        ControllerControlsNoOtherCreaturesCondition condition)
    {
    }

    public ICondition Copy()
    {
        return new ControllerControlsNoOtherCreaturesCondition(this);
    }

    public bool IsMet(ICreature creature)
    {
        return !battleZone.HasOtherCreaturesControllerByPlayer(creature, filter);
    }
}