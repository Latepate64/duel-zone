namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    public abstract class AutomaticAction : PlayerAction
    {
        protected AutomaticAction(Player player) : base(player) { }

        public override bool PerformAutomatically(Duel duel)
        {
            Perform(duel);
            return true;
        }

        public abstract PlayerAction Perform(Duel duel);
    }
}
