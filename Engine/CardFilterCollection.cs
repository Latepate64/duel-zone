using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine
{
    public class CardFilterCollection : Collection<CardFilter>
    {
        public bool AndInsteadOfOr { get; }

        public CardFilterCollection(bool andInsteadOfOr, IList<CardFilter> cardFilters) : base(cardFilters)
        {
            AndInsteadOfOr = andInsteadOfOr;
        }

        public bool Applies(Card card, Game game, Player player)
        {
            return AndInsteadOfOr ? Items.All(x => x.Applies(card, game, player)) : Items.Any(x => x.Applies(card, game, player));
        }
    }

    public class Filter : Collection<CardFilterCollection>
    {
        public bool Applies(Card card, Game game, Player player)
        {
            return Items.All(x => x.Applies(card, game, player));
        }
    }
}
