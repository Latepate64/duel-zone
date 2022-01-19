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

        public override Step GetNextStep(Duel duel)
        {
            return new MainStep();
        }

        protected internal override bool PerformPriorityAction(Duel duel)
        {
            var player = duel.GetPlayer(duel.CurrentTurn.ActivePlayer);
            var dec = player.Choose(new GuidSelection(duel.CurrentTurn.ActivePlayer, duel.GetPlayer(duel.CurrentTurn.ActivePlayer).Hand.Cards, 0, 1));
            var cards = dec.Decision;
            if (cards.Any())
            {
                _ = duel.Move(cards.Select(x => duel.GetCard(x)), Zones.ZoneType.Hand, Zones.ZoneType.ManaZone);
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
