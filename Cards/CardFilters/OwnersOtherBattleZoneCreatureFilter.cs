using Engine;
using System;

namespace Cards.CardFilters
{
    class OwnersOtherBattleZoneCreatureFilter : OwnersBattleZoneCreatureFilter, ITargetFilterable
    {
        public OwnersOtherBattleZoneCreatureFilter() : base()
        {
        }

        public OwnersOtherBattleZoneCreatureFilter(OwnersOtherBattleZoneCreatureFilter filter) : base()
        {
            Target = filter.Target;
        }

        public Guid Target { get; set; }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && Target == card?.Id;
        }

        public override CardFilter Copy()
        {
            return new OwnersOtherBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your other creatures";
        }
    }
}
