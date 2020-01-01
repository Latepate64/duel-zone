using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of cards player has selected.
    /// </summary>
    public class CardSelectionResponse : PlayerActionResponse
    {
        internal ReadOnlyCardCollection SelectedCards { get; }

        /// <summary>
        /// Creates a card selection response that contains no cards.
        /// </summary>
        public CardSelectionResponse()
        {
            SelectedCards = new ReadOnlyCardCollection();
        }

        /// <summary>
        /// Creates a card selection response from card.
        /// </summary>
        /// <param name="selectedCard">Cards player has selected.</param>
        public CardSelectionResponse(Card selectedCard)
        {
            SelectedCards = new ReadOnlyCardCollection(selectedCard);
        }

        /// <summary>
        /// Creates a card selection response from card collection.
        /// </summary>
        /// <param name="selectedCards">Cards player has selected.</param>
        public CardSelectionResponse(ReadOnlyCardCollection selectedCards)
        {
            SelectedCards = selectedCards;
        }
    }
}
