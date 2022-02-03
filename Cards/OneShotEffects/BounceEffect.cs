using Common;
using Engine;

namespace Cards.OneShotEffects
{
    /// <summary>
    /// Choose up to X creatures in the battle zone and return them to their owners' hands.
    /// </summary>
    class BounceEffect : CardMovingChoiceEffect
    {
        public BounceEffect(int minimum, int maximum, CardFilter cardFilter) : base(cardFilter, minimum, maximum, true, ZoneType.BattleZone, ZoneType.Hand)
        {
        }
    }
}
