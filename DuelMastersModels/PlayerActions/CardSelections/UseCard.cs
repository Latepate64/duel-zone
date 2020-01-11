using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Depending on the card type, to use a card means one of the following: summon a creature, cast a spell, generate a cross gear, fortify the shield at the castle, or expand a field.
    /// </summary>
    public class UseCard : OptionalCardSelection
    {
        internal UseCard(Player player, ReadOnlyCardCollection cards) : base(player, cards)
        { }

        internal override PlayerAction Perform(Duel duel, Card card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep)
            {
                if (card != null)
                {
                    // 601.1a The card leaves the zone it is currently in (usually the player's hand) and is moved to the anywhere zone.
                    Player.Hand.Remove(card, duel);
                    mainStep.CardToBeUsed = card;
                    mainStep.State = MainStepState.Pay;
                }
                else
                {
                    mainStep.State = MainStepState.MustBeEnded;
                }
                return null;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}