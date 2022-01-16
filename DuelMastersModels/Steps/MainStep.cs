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

        protected internal override void PerformPriorityAction(Decision decision, Duel duel)
        {
            if (decision == null)
            {
                var usableCards = duel.GetPlayer(duel.CurrentTurn.ActivePlayer).GetUsableCardsWithPaymentInformation();
                if (usableCards.Any())
                {
                    duel.SetAwaitingChoice(new CardUsageChoice(duel.CurrentTurn.ActivePlayer, usableCards));
                }
                else
                {
                    PassPriority = true;
                }
            }
            else
            {
                //duel.ClearAwaitingChoice();
                var usage = decision as CardUsageDecision;
                if (usage.Decision == null)
                {
                    PassPriority = true;
                }
                else
                {
                    foreach (Card mana in usage.Decision.Manas.Select(x => duel.GetCard(x)))
                    {
                        mana.Tapped = true;
                    }
                    duel.UseCard(duel.GetCard(usage.Decision.ToUse), duel.GetPlayer(duel.CurrentTurn.ActivePlayer));
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
