using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActionResponses
{
    public class CardSelectionResponse : PlayerActionResponse
    {
        public Collection<Card> SelectedCards { get; } = new Collection<Card>();

        public CardSelectionResponse() { }

        public CardSelectionResponse(Collection<Card> selectedCards)
        {
            SelectedCards = selectedCards;
        }
    }
}
