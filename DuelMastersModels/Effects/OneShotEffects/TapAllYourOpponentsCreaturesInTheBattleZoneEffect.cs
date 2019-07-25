using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class TapAllYourOpponentsCreaturesInTheBattleZoneEffect : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.AutomaticActions.TapAllYourOpponentsCreaturesInTheBattleZone(player);
        }
    }
}