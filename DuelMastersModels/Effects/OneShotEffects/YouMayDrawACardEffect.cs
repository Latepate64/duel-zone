using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class YouMayDrawACardEffect : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.OptionalActions.YouMayDrawACard(player);
        }
    }
}
