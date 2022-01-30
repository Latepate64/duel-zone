using DuelMastersModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.CardFilters
{
    public class TargetsFilter : CardFilter
    {
        public List<Guid> Cards { get; }

        public TargetsFilter(IEnumerable<Guid> cards)
        {
            Cards = cards.ToList();
        }

        public TargetsFilter(TargetsFilter filter) : base(filter)
        {
            Cards = filter.Cards;
        }

        public override CardFilter Copy()
        {
            return new TargetsFilter(this);
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return card != null && Cards.Contains(card.Id);
        }
    }
}
