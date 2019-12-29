using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class YouMayDrawACardEffect : OneShotEffect
    {
        internal override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.OptionalActions.YouMayDrawACard(player);
        }
    }
}
