using DuelMastersCards.CardFilters;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    /// <summary>
    /// Choose up to X creatures in the battle zone and return them to their owners' hands.
    /// </summary>
    class BounceEffect : CardMovingChoiceEffect
    {
        public BounceEffect(int minimum, int maximum) : base(ZoneType.BattleZone, ZoneType.Hand, new BattleZoneChoosableCreatureFilter(), minimum, maximum, true)
        {
        }
    }
}
