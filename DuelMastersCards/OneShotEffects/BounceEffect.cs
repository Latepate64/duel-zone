using DuelMastersCards.CardFilters;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    /// <summary>
    /// Choose up to X creatures in the battle zone and return them to their owners' hands.
    /// </summary>
    class BounceEffect : CardMovingChoiceEffect
    {
        public BounceEffect(int maximum) : base(ZoneType.BattleZone, ZoneType.Hand, new BattleZoneChoosableCreatureFilter(), 0, maximum, true)
        {
        }

        public BounceEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }
    }
}
