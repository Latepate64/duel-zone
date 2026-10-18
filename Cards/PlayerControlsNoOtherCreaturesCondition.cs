using Interfaces;
using Interfaces.Zones;

namespace Cards;

public class PlayerControlsNoOtherCreaturesCondition : IConditionWithBattleZoneCreatureAndFilter
{
    public bool IsMet(IBattleZone battleZone, ICreature creature, ICardFilter filter)
    {
        return !battleZone.HasOtherCreaturesControllerByPlayer(creature, filter);
    }
}