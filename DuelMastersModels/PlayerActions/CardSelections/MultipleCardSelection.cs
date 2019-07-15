using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class MultipleCardSelection : CardSelection
    {
        protected MultipleCardSelection(Player player, Collection<Card> cards) : base(player, 0, cards.Count, cards)
        { }

        public Collection<Card> SelectedCards { get; } = new Collection<Card>();

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

        public bool Validate(Collection<Card> cards)
        {
            return !cards.Except(Cards).Any();
        }

        public abstract PlayerAction Perform(Duel duel, Collection<Card> cards);
    }
}