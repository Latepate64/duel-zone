namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class AddTheTopCardOfYourDeckToYourShieldsFaceDown : AutomaticAction
    {
        internal AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player) : base(player) { }

        internal override PlayerAction Perform(Duel duel)
        {
            return duel.AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player);
        }
    }
}
