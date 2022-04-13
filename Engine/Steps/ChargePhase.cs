using Common.Choices;
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
            var dec = game.CurrentTurn.ActivePlayer.Choose(new ChargeManaSelection(game.CurrentTurn.ActivePlayer.Id, game.CurrentTurn.ActivePlayer.Hand.Cards), game);
            var cards = dec.Decision;
            if (cards.Any())
            {
                _ = game.Move(Common.ZoneType.Hand, Common.ZoneType.ManaZone, cards.Select(x => game.GetCard(x)).ToArray());
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
