using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class ChargeMana : OptionalCardSelection
    {
        public ChargeMana(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override string Message
        {
            get
            {
                if (SelectedCard != null)
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} charged mana with {1}.", Player.Name, SelectedCard.Name);
                }
                else
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} did not charge mana.", Player.Name);
                }
            }
        }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (SelectedCard != null)
            {
                Duel.PutFromHandIntoManaZone(Player, SelectedCard);
            }
        }
    }
}
