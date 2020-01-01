using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a card.
    /// </summary>
    public abstract class MandatoryCardSelection : CardSelection
    {
        internal MandatoryCardSelection(Player player, ReadOnlyCardCollection cards) : base(player, 1, 1, cards)
        { }

        internal Card SelectedCard { get; set; }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Cards.Count == 1)
            {
                SelectedCard = Cards[0];
                duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
                return Perform(duel, Cards[0]);
            }
            else
            {
                return this;
            }
        }

        internal bool Validate(Card card)
        {
            return Cards.Contains(card);
        }

        internal abstract PlayerAction Perform(Duel duel, Card card);
    }
}