using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class UseCard : OptionalCardSelection
    {
        public UseCard(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override void Perform(Duel duel, Card card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep)
            {
                if (card != null)
                {
                    // 601.1a The card leaves the zone it is currently in (usually the player's hand) and is moved to the anywhere zone.
                    Player.Hand.Remove(card);
                    mainStep.CardToBeUsed = card;
                    mainStep.State = MainStepState.Pay;
                }
                else
                {
                    mainStep.State = MainStepState.MustBeEnded;
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}