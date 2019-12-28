using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    public class CardSelectionResponse : PlayerActionResponse
    {
        public ReadOnlyCardCollection SelectedCards { get; }

        public CardSelectionResponse(ReadOnlyCardCollection selectedCards)
        {
            SelectedCards = selectedCards;
        }
    }
}
