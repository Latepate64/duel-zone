using Interfaces;
using Interfaces.Zones;

namespace TriggeredAbilities;

public class BattleshipMutantAbilityFactory : ITriggeredAbilityFactory
{
    public ITriggeredAbility Create(
        IBattleZone battleZone, IPlayerV2 player, ICardFilter filter)
    {
        return new BattleshipMutantAbility(
            battleZone.GetCreaturesControlledByPlayer(
                player,
                filter));
    }
}