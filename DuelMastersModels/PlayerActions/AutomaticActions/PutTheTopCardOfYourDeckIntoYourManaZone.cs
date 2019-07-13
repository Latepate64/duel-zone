namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    public class PutTheTopCardOfYourDeckIntoYourManaZone : AutomaticAction
    {
        public PutTheTopCardOfYourDeckIntoYourManaZone(Player player) : base(player) { }

        public override PlayerAction Perform(Duel duel)
        {
            return duel.PutTheTopCardOfYourDeckIntoYourManaZone(Player);
        }
    }
}
