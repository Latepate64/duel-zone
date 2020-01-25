using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of cards player has selected.
    /// </summary>
    public class CardSelectionResponse<TCard> : PlayerActionResponse where TCard : class, ICard
    {
        internal ReadOnlyCardCollection<TCard> SelectedCards { get; }

        /// <summary>
        /// Creates a card selection response that contains no cards.
        /// </summary>
        public CardSelectionResponse()
        {
            SelectedCards = new ReadOnlyCardCollection<TCard>();
        }

        /// <summary>
        /// Creates a card selection response from card.
        /// </summary>
        /// <param name="selectedCard">Cards player has selected.</param>
        public CardSelectionResponse(TCard selectedCard)
        {
            SelectedCards = new ReadOnlyCardCollection<TCard>(selectedCard);
        }

        /// <summary>
        /// Creates a card selection response from card collection.
        /// </summary>
        /// <param name="selectedCards">Cards player has selected.</param>
        public CardSelectionResponse(ReadOnlyCardCollection<TCard> selectedCards)
        {
            SelectedCards = selectedCards;
        }
    }
}
