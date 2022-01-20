using DuelMastersModels;
using DuelMastersModels.Zones;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class ZoneFilter : CardFilter
    {
        ZoneType Zone { get; }

        public ZoneFilter(ZoneType zone)
        {
            Zone = zone;
        }

        public ZoneFilter(ZoneFilter filter) : base(filter)
        {
            Zone = filter.Zone;
        }

        public override bool Applies(Card card, Game game)
        {
            return game.Players.SelectMany(x => x.GetZone(Zone).Cards).Any(x => x.Id == card.Id);
        }

        public override CardFilter Copy()
        {
            return new ZoneFilter(this);
        }
    }
}
