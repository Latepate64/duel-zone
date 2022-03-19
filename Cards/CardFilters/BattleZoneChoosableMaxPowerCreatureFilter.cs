﻿using Engine;

namespace Cards.CardFilters
{
    class BattleZoneChoosableMaxPowerCreatureFilter : BattleZoneChoosableCreatureFilter, IPowerFilterable
    {
        public BattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            PowerFilter = new PowerFilter(CompareMode.Max, power);
        }

        public BattleZoneChoosableMaxPowerCreatureFilter(BattleZoneChoosableMaxPowerCreatureFilter filter) : base()
        {
            PowerFilter = filter.PowerFilter;
        }

        public PowerFilter PowerFilter { get; set; }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && PowerFilter.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneChoosableMaxPowerCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"creature {PowerFilter}";
        }
    }
}
