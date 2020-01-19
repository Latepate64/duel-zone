using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of cards player has selected.
    /// </summary>
    public class CardSelectionResponse<TZoneCard> : PlayerActionResponse where TZoneCard : IZoneCard
    {
        internal ReadOnlyCardCollection<TZoneCard> SelectedCards { get; }

        /// <summary>
        /// Creates a card selection response that contains no cards.
        /// </summary>
        public CardSelectionResponse()
        {
            SelectedCards = new ReadOnlyCardCollection<TZoneCard>();
        }

        /// <summary>
        /// Creates a card selection response from card.
        /// </summary>
        /// <param name="selectedCard">Cards player has selected.</param>
        public CardSelectionResponse(TZoneCard selectedCard)
        {
            SelectedCards = new ReadOnlyCardCollection<TZoneCard>(selectedCard);
        }

        /// <summary>
        /// Creates a card selection response from card collection.
        /// </summary>
        /// <param name="selectedCards">Cards player has selected.</param>
        public CardSelectionResponse(ReadOnlyCardCollection<TZoneCard> selectedCards)
        {
            SelectedCards = selectedCards;
        }
    }
}
