using System.Linq;

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
            var cards = game.CurrentTurn.ActivePlayer.ChooseCards(game.CurrentTurn.ActivePlayer.Hand.Cards, 0, 1, "You may put a card from your hand into your mana zone.");
            if (cards.Any())
            {
                _ = game.Move(Common.ZoneType.Hand, Common.ZoneType.ManaZone, cards.ToArray());
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
