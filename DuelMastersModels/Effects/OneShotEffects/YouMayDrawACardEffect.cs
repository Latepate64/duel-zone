using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class YouMayDrawACardEffect : OneShotEffect
    {
        internal override IPlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.OptionalActions.YouMayDrawACard(player);
        }
    }
}
