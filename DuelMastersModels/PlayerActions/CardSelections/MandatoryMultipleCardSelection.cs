using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class MandatoryMultipleCardSelection : CardSelection
    {
        public Collection<Card> SelectedCards { get; private set; } = new Collection<Card>();

        protected MandatoryMultipleCardSelection(Player player, int amount, Collection<Card> cards) : base(player, amount, amount, cards)
        {
        }

        public override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Cards.Count <= MaximumSelection)
            {
                SelectedCards = Cards;
                duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
                return Perform(duel, Cards);
            }
            else
            {
                return this;
            }
        }

        public abstract PlayerAction Perform(Duel duel, Collection<Card> cards);

        public bool Validate(Collection<Card> cards)
        {
            return cards.Count == MinimumSelection && !cards.Except(Cards).Any();
        }
    }
}
