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

        public override bool PerformAutomatically(Duel duel)
        {
            return Cards.Count == 0;
        }

        public bool Validate(Collection<Card> cards)
        {
            return !cards.Except(Cards).Any();
        }

        public abstract PlayerAction Perform(Duel duel, Collection<Card> cards);
    }
}