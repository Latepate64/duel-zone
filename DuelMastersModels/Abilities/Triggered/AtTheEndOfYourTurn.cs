namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class AtTheEndOfYourTurn : TriggeredAbility
    {
        protected AtTheEndOfYourTurn() : base()
        {
        }

        protected AtTheEndOfYourTurn(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(Duel duel, System.Guid controller)
        {
            return duel.CurrentTurn.ActivePlayer == controller;
        }
    }
}
