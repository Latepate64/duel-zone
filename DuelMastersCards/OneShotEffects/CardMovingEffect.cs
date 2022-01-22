using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    abstract class CardMovingEffect : OneShotEffect
    {
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }
        public CardFilter Filter { get; }

        public CardMovingEffect(ZoneType source, ZoneType destination, CardFilter filter)
        {
            SourceZone = source;
            DestinationZone = destination;
            Filter = filter;
        }

        public CardMovingEffect(CardMovingEffect effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
            Filter = effect.Filter;
        }
    }
}
