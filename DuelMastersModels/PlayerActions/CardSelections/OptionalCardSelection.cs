using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class OptionalCardSelection : CardSelection
    {
        protected OptionalCardSelection(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override bool SelectAutomatically()
        {
            return Cards.Count == 0;
        }
    }
}
