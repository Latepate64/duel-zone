using Interfaces.Zones;

namespace Interfaces;

public interface ITriggeredAbilityFactory
{
    ITriggeredAbility Create(
        IBattleZone battleZone, IPlayerV2 player, ICardFilter filter);
}