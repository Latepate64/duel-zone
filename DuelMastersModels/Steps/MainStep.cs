using DuelMastersModels.Choices;
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

        protected internal override Choice PerformPriorityAction(Decision choice, Duel duel)
        {
            if (choice == null)
            {
                var usableCards = duel.GetPlayer(duel.CurrentTurn.ActivePlayer).GetUsableCardsWithPaymentInformation();
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
                var usage = choice as CardUsageDecision;
                if (usage.Decision == null)
                {
                    PassPriority = true;
                    return null;
                }
                else
                {
                    foreach (Card mana in usage.Decision.Manas.Select(x => duel.GetCard(x)))
                    {
                        mana.Tapped = true;
                    }
                    duel.UseCard(duel.GetCard(usage.Decision.ToUse), duel.GetPlayer(duel.CurrentTurn.ActivePlayer));
                    return null;
                }
            }
        }

        public override Step GetNextStep(Duel duel)
        {
            return new AttackDeclarationStep();
        }

        public MainStep(MainStep step) : base(step) { }

        public override Step Copy()
        {
            return new MainStep(this);
        }
    }
}
