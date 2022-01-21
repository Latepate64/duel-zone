using DuelMastersCards.CardFilters;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    /// <summary>
    /// Choose up to X creatures in the battle zone and return them to their owners' hands.
    /// </summary>
    class BounceEffect : CardMovingEffect
    {
        public BounceEffect(int maximum) : base(ZoneType.BattleZone, ZoneType.Hand, 0, maximum, true, new ChoosableCreatureFilter())
        {
        }

        public BounceEffect(CardMovingEffect effect) : base(effect)
        {
        }
    }
}
