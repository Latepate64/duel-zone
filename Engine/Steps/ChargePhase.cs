namespace Engine.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargePhase : PriorityPhase
    {
        public ChargePhase() : base(PhaseOrStep.Charge)
        {
        }

        public override IPhase GetNextPhase(IGame game)
        {
            return new MainPhase();
        }

        protected internal override bool PerformPriorityAction(IGame game)
        {
            var card = game.CurrentTurn.ActivePlayer.ChooseCardOptionally(game.CurrentTurn.ActivePlayer.Hand.Cards, "You may put a card from your hand into your mana zone.");
            if (card != null)
            {
                _ = game.Move(null, ZoneType.Hand, ZoneType.ManaZone, card);
            }
            return true;
        }

        public override IPhase Copy()
        {
            return new ChargePhase(this);
        }

        public ChargePhase(ChargePhase step) : base(step) { }
    }
}
