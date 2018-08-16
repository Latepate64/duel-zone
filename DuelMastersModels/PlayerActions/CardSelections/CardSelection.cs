using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class CardSelection : PlayerAction
    {
        public Collection<Card> Cards { get; private set; }
        public Card SelectedCard { get; set; }

        protected CardSelection(Player player, Collection<Card> cards) : base(player)
        {
            Cards = cards;
        }
    }
}
