using Engine;
using System;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureExceptFilter : OwnersBattleZoneCreatureFilter, ITargetFilterable
    {
        public OwnersBattleZoneCreatureExceptFilter() : base()
        {
        }

        public OwnersBattleZoneCreatureExceptFilter(OwnersBattleZoneCreatureExceptFilter filter) : base()
        {
            Target = filter.Target;
        }

        public Guid Target { get; set; }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && Target == card?.Id;
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCreatureExceptFilter(this);
        }

        public override string ToString()
        {
            return $"your other creatures";
        }
    }
}
