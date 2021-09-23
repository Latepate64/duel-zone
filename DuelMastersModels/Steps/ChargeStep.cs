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

        public override Step GetNextStep()
        {
            return new MainStep();
        }

        protected internal override Choice PerformPriorityAction(Choice choice, Duel duel)
        {
            if (choice == null)
            {
                return new Selection<Cards.Card>(duel.CurrentTurn.ActivePlayer, duel.CurrentTurn.ActivePlayer.Hand.Cards);
            }
            else
            {
                var cards = (choice as Selection<Cards.Card>).Selected;
                if (cards.Any()) { duel.CurrentTurn.ActivePlayer.PutFromHandIntoManaZone(cards.Single()); }
                PassPriority = true;
                return null;
            }
        }

        public override Step Copy()
        {
            return Copy(new ChargeStep
            {
                PassPriority = PassPriority
            });
        }
    }
}
