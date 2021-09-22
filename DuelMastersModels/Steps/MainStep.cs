using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main step.
    /// </summary>
    public class MainStep : PriorityStep
    {
        public MainStep()
        {
        }

        protected internal override Choice PerformPriorityAction(Choice choice, Duel duel)
        {
            if (choice == null)
            {
                var usableCards = duel.CurrentTurn.ActivePlayer.GetUsableCardsWithPaymentInformation();
                if (usableCards.Any())
                {
                    return new CardUsageChoice(duel.CurrentTurn.ActivePlayer, usableCards);
                }
                else
                {
                    PassPriority = true;
                    return null;
                }
            }
            else
            {
                var usage = choice as CardUsageChoice;
                if (usage.Selected == null)
                {
                    PassPriority = true;
                    return null;
                }
                else
                {
                    foreach (Card mana in usage.Selected)
                    {
                        mana.Tapped = true;
                    }
                    duel.UseCard(usage.Selected.Key);
                    return null;
                }
            }
        }

        //TODO
        //public override Choice PlayerActionRequired(Duel duel)
        //{
        //    //IEnumerable<Card> usableCards = GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
        //    throw new System.NotImplementedException();
        //    //return State == MainStepState.Use && usableCards.Any()
        //    //    ? new UseCard(ActivePlayer, usableCards)
        //    //    : (Choice)(State == MainStepState.Pay ? new PayCost(ActivePlayer, ActivePlayer.ManaZone.UntappedCards, CardToBeUsed.Cost) : null);
        //}

        /// <summary>
        /// Returns the cards that can be used.
        /// </summary>
        public static IEnumerable<Card> GetUsableCards(IEnumerable<Card> handCards, IEnumerable<Card> manaCards)
        {
            return handCards.Where(handCard => Duel.CanBeUsed(handCard, manaCards));
        }

        public override Step GetNextStep()
        {
            return new AttackDeclarationStep();
        }
    }
}
