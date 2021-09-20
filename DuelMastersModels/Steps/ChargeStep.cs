using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : PriorityStep
    {
        public Card ChargedCard { get; set; }

        public ChargeStep(IPlayer player) : base(player)
        {
        }

        public Choice ChargeMana(Card card, Duel duel)
        {
            if (ChargedCard != null)
            {
                throw new InvalidOperationException("Mana has already been charged during this step.");
            }
            else if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            ActivePlayer.PutFromHandIntoManaZone(card);
            ChargedCard = card;
            return Proceed(null, duel);
        }

        public override Step GetNextStep()
        {
            return new MainStep(ActivePlayer);
        }

        protected internal override Choice PerformPriorityAction(Choice choice)
        {
            State = StepState.PriorityAction;
            if (ChargedCard != null)
            {
                return null;
            }
            else
            {
                return new ChargeChoice(ActivePlayer);
            }
        }
    }
}
