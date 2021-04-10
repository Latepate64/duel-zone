using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class TapAllYourOpponentsCreaturesInTheBattleZoneEffect : OneShotEffect
    {
        internal override IPlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.AutomaticActions.TapAllYourOpponentsCreaturesInTheBattleZone(player);
        }
    }
}