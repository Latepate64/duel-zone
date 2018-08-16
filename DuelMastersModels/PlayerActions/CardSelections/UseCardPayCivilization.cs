using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class UseCardPayCivilization : MandatoryCardSelection
    {
        public UseCardPayCivilization(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override string Message
        {
            get
            {
                return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} paid civilization mana with {1}.", Player.Name, SelectedCard.Name);
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
                    SelectedCard.Tapped = true;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}