using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.CreatureSelections.YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(player, duel.CreaturesInTheBattleZone);
        }
    }
}
