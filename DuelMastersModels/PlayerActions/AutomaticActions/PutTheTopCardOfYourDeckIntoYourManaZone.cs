namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class PutTheTopCardOfYourDeckIntoYourManaZone : AutomaticAction
    {
        public PutTheTopCardOfYourDeckIntoYourManaZone(IPlayer player) : base(player) { }

        internal override PlayerAction Perform(IDuel duel)
        {
            return duel.PutTheTopCardOfYourDeckIntoYourManaZone(Player);
        }
    }
}
