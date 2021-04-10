using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class YouMayDrawACardEffect : OneShotEffect
    {
        internal override PlayerAction Apply(Duel duel, IPlayer player)
        {
            return new PlayerActions.OptionalActions.YouMayDrawACard(player);
        }
    }
}
