namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    public class PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown : AutomaticAction
    {
        public PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player) : base(player) { }

        public override PlayerAction Perform(Duel duel)
        {
            return duel.PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown(Player);
        }
    }
}
