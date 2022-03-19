using Engine;
using System;

namespace Cards.CardFilters
{
    class AnotherBattleZoneCreatureFilter : BattleZoneCreatureFilter, ITargetFilterable
    {
        public AnotherBattleZoneCreatureFilter()
        {
        }

        public AnotherBattleZoneCreatureFilter(AnotherBattleZoneCreatureFilter filter)
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
            return new AnotherBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return "another creature";
        }
    }
}
