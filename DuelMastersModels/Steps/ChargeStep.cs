using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : PriorityStep
    {
        public ChargeStep()
        {
        }

        public override Step GetNextStep(Game game)
        {
            return new MainStep();
        }

        protected internal override bool PerformPriorityAction(Game game)
        {
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            var dec = player.Choose(new GuidSelection(game.CurrentTurn.ActivePlayer, game.GetPlayer(game.CurrentTurn.ActivePlayer).Hand.Cards, 0, 1));
            var cards = dec.Decision;
            if (cards.Any())
            {
                _ = game.Move(cards.Select(x => game.GetCard(x)), Zones.ZoneType.Hand, Zones.ZoneType.ManaZone);
            }
            return true;
        }

        public override Step Copy()
        {
            return new ChargeStep(this);
        }

        public ChargeStep(ChargeStep step) : base(step) { }
    }
}
