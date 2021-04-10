using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Depending on the card type, to use a card means one of the following: summon a creature, cast a spell, generate a cross gear, fortify the shield at the castle, or expand a field.
    /// </summary>
    public class UseCard : OptionalCardSelection<IHandCard>
    {
        internal UseCard(IPlayer player, IEnumerable<IHandCard> cards) : base(player, cards)
        { }

        public override IPlayerAction Perform(IDuel duel, IHandCard card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else if (duel.TurnManager.CurrentTurn.CurrentStep is MainStep mainStep)
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
                return null;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}