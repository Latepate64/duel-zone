namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    public class AddTheTopCardOfYourDeckToYourShieldsFaceDown : AutomaticAction
    {
        public AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player) : base(player) { }

        public override PlayerAction Perform(Duel duel)
        {
            return duel.AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player);
        }
    }
}
