using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect : OneShotEffect
    {
        internal override IPlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.AutomaticActions.AddTheTopCardOfYourDeckToYourShieldsFaceDown(player);
        }
    }
}
