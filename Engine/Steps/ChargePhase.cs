using Common.Choices;
using System.Linq;

namespace Engine.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargePhase : PriorityPhase
    {
        public ChargePhase() : base(Common.GameEvents.PhaseOrStep.Charge)
        {
        }

        public override Phase GetNextPhase(Game game)
        {
            return new MainPhase();
        }

        protected internal override bool PerformPriorityAction(Game game)
        {
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer.Id);
            var dec = player.Choose(new ChargeManaSelection(game.CurrentTurn.ActivePlayer.Id, game.GetPlayer(game.CurrentTurn.ActivePlayer.Id).Hand.Cards), game);
            var cards = dec.Decision;
            if (cards.Any())
            {
                _ = game.Move(Common.ZoneType.Hand, Common.ZoneType.ManaZone, cards.Select(x => game.GetCard(x)).ToArray());
            }
            return true;
        }

        public override Phase Copy()
        {
            return new ChargePhase(this);
        }

        public ChargePhase(ChargePhase step) : base(step) { }
    }
}
