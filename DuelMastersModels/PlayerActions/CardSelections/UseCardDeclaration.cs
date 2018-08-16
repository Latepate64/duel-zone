using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class UseCardDeclaration : OptionalCardSelection
    {
        public UseCardDeclaration(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override string Message
        {
            get
            {
                if (SelectedCard != null)
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} used {1}.", Player.Name, SelectedCard.Name);
                }
                else
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} used no cards.", Player.Name);
                }
            }
        }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep)
            {
                if (SelectedCard != null)
                {
                    // 601.1a The card leaves the zone it is currently in (usually the player's hand) and is moved to the anywhere zone.
                    Player.Hand.Remove(SelectedCard);
                }
                else
                {
                    mainStep.EndStep();
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}