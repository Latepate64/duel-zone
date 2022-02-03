using Common.Choices;
using System.Linq;

namespace Engine.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargePhase : PriorityPhase
    {
        public ChargePhase()
        {
        }

        public override Phase GetNextPhase(Game game)
        {
            return new MainPhase();
        }

        protected internal override bool PerformPriorityAction(Game game)
        {
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            var dec = player.Choose(new GuidSelection(game.CurrentTurn.ActivePlayer, game.GetPlayer(game.CurrentTurn.ActivePlayer).Hand.Cards, 0, 1));
            var cards = dec.Decision;
            if (cards.Any())
            {
                _ = game.Move(cards.Select(x => game.GetCard(x)), Common.ZoneType.Hand, Common.ZoneType.ManaZone);
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
