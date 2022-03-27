using Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.CardFilters
{
    class TargetsFilter : CardFilter
    {
        public List<Guid> Cards { get; }

        public TargetsFilter(params ICard[] cards)
        {
            Cards = cards.Select(x => x.Id).ToList();
        }

        public TargetsFilter(TargetsFilter filter) : base()
        {
            Cards = filter.Cards;
        }

        public override CardFilter Copy()
        {
            return new TargetsFilter(this);
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return card != null && Cards.Contains(card.Id);
        }

        public override string ToString()
        {
            return string.Join(", ", Cards);
        }
    }
}
