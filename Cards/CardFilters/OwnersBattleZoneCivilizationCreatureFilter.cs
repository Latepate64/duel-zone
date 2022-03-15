﻿using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCivilizationCreatureFilter : OwnersBattleZoneCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OwnersBattleZoneCivilizationCreatureFilter(Common.Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OwnersBattleZoneCivilizationCreatureFilter(OwnersBattleZoneCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your {CivilizationFilter} {ToStringBase()}s";
        }
    }
}