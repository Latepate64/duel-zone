using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class BounceEffect : CardMovingChoiceEffect
    {
        protected BounceEffect(CardFilter cardFilter, int minimum, int maximum) : base(cardFilter, minimum, maximum, true, ZoneType.BattleZone, ZoneType.Hand)
        {
        }

        protected BounceEffect(BounceEffect effect) : base(effect)
        {
        }
    }
}
