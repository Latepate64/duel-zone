using Interfaces.Zones;

namespace Interfaces;

public interface IConditionWithBattleZoneCreatureAndFilter
{
    bool IsMet(IBattleZone battleZone, ICreature creature, ICardFilter filter);
}
