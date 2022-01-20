using DuelMastersModels;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class PlayerFilter : CardFilter
    {
        public bool OwnerInsteadOfOpponent { get; }

        public PlayerFilter(bool ownerInsteadOfOpponent)
        {
            OwnerInsteadOfOpponent = ownerInsteadOfOpponent;
        }

        public PlayerFilter(PlayerFilter filter) : base(filter)
        {
            OwnerInsteadOfOpponent = filter.OwnerInsteadOfOpponent;
        }

        public override bool Applies(Card card, Game game)
        {
            var owner = game.GetPlayer(Owner);
            if (OwnerInsteadOfOpponent)
            {
                return game.GetPlayer(Owner).AllCards.Contains(card);
            }
            else
            {
                return game.GetOpponent(owner).AllCards.Contains(card);
            }
        }

        public override CardFilter Copy()
        {
            return new PlayerFilter(this);
        }
    }
}
