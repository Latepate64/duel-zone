using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class MultipleCardSelection : CardSelection
    {
        protected MultipleCardSelection(Player player, ReadOnlyCardCollection cards) : base(player, 0, cards.Count, cards)
        { }

        public CardCollection SelectedCards { get; } = new CardCollection();

        public override PlayerAction TryToPerformAutomatically(Duel duel)
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

        public bool Validate(ReadOnlyCardCollection cards)
        {
            return !cards.Except(Cards).Any();
        }

        public abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards);
    }
}