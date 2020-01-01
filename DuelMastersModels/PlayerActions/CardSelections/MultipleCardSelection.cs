using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class MultipleCardSelection : CardSelection
    {
        internal MultipleCardSelection(Player player, ReadOnlyCardCollection cards) : base(player, 0, cards.Count, cards)
        { }

        internal CardCollection SelectedCards { get; } = new CardCollection();

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Cards.Count == 0)
            {
                return Perform(duel, Cards);
            }
            else
            {
                return this;
            }
        }

        internal bool Validate(ReadOnlyCardCollection cards)
        {
            return !cards.Except(Cards).Any();
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards);
    }
}