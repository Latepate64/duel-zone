using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions
{
    public abstract class MandatoryCardSelection : CardSelection
    {
        protected MandatoryCardSelection(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override bool SelectAutomatically()
        {
            if (Cards.Count == 1)
            {
                SelectedCard = Cards.First();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
