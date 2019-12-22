using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class MandatoryMultipleCardSelection : CardSelection
    {
        public ReadOnlyCardCollection SelectedCards { get; private set; }

        protected MandatoryMultipleCardSelection(Player player, int amount, ReadOnlyCardCollection cards) : base(player, amount, amount, cards)
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

        public abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards);

        public bool Validate(ReadOnlyCardCollection cards)
        {
            return cards.Count == MinimumSelection && !cards.Except(Cards).Any();
        }
    }
}
