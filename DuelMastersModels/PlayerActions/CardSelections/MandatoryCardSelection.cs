using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class MandatoryCardSelection : CardSelection
    {
        protected MandatoryCardSelection(Player player, Collection<Card> cards) : base(player, 1, 1, cards)
        { }

        public Card SelectedCard { get; set; }

        public override bool PerformAutomatically(Duel duel)
        {
            if (Cards.Count == 1)
            {
                SelectedCard = Cards[0];
                Perform(duel, Cards[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Validate(Card card)
        {
            return Cards.Contains(card);
        }

        public abstract PlayerAction Perform(Duel duel, Card card);
    }
}