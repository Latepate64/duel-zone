using DuelMastersModels;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class OwnerFilter : CardFilter
    {
        public bool OwnerInsteadOfOpponent { get; }

        public OwnerFilter(bool ownerInsteadOfOpponent)
        {
            OwnerInsteadOfOpponent = ownerInsteadOfOpponent;
        }

        public OwnerFilter(OwnerFilter filter) : base(filter)
        {
            OwnerInsteadOfOpponent = filter.OwnerInsteadOfOpponent;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            if (OwnerInsteadOfOpponent)
            {
                return game.GetAllCards(player.Id).Contains(card);
            }
            else
            {
                return game.GetAllCards(game.GetOpponent(player).Id).Contains(card);
            }
        }

        public override CardFilter Copy()
        {
            return new OwnerFilter(this);
        }
    }
}
