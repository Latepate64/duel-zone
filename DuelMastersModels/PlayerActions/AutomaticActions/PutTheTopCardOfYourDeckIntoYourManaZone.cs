namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class PutTheTopCardOfYourDeckIntoYourManaZone : AutomaticAction
    {
        public PutTheTopCardOfYourDeckIntoYourManaZone(Player player) : base(player) { }

        internal override PlayerAction Perform(Duel duel)
        {
            return duel.PutTheTopCardOfYourDeckIntoYourManaZone(Player);
        }
    }
}
