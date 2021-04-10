namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class AddTheTopCardOfYourDeckToYourShieldsFaceDown : AutomaticAction
    {
        internal AddTheTopCardOfYourDeckToYourShieldsFaceDown(IPlayer player) : base(player) { }

        internal override PlayerAction Perform(IDuel duel)
        {
            return duel.AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player);
        }
    }
}
