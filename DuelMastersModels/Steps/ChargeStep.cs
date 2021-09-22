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
                return new Choices.CardSelections.CardSelection<Cards.Card>(duel.CurrentTurn.ActivePlayer, duel.CurrentTurn.ActivePlayer.Hand.Cards);
            }
            else
            {
                var cards = (choice as Choices.CardSelections.CardSelection<Cards.Card>).SelectedCards;
                if (cards.Any()) { duel.CurrentTurn.ActivePlayer.PutFromHandIntoManaZone(cards.Single()); }
                PassPriority = true;
                return null;
            }
        }
    }
}
