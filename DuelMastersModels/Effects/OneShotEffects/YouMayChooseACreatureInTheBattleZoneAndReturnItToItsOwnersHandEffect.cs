using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : OneShotEffect
    {
        internal override IPlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.CreatureSelections.YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand(player, duel.CreaturesInTheBattleZone);
        }
    }
}
