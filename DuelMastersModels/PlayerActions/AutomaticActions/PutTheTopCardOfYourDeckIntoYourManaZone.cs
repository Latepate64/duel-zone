namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class PutTheTopCardOfYourDeckIntoYourManaZone : AutomaticAction
    {
        public PutTheTopCardOfYourDeckIntoYourManaZone(IPlayer player) : base(player) { }

        internal override PlayerAction Perform(Duel duel)
        {
            return duel.PutTheTopCardOfYourDeckIntoYourManaZone(Player);
        }
    }
}
