using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            //return new PlayerActions.AutomaticActions.PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown(player); //TODO: remove
            return new PlayerActions.AutomaticActions.AddTheTopCardOfYourDeckToYourShieldsFaceDown(player);
        }
    }
}
