using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect : OneShotEffect
    {
        internal override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.AutomaticActions.AddTheTopCardOfYourDeckToYourShieldsFaceDown(player);
        }
    }
}
