using Engine;

namespace Cards.OneShotEffects
{
    abstract class BounceEffect : CardMovingChoiceEffect<Engine.Creature>
    {
        protected BounceEffect(int minimum, int maximum) : base(minimum, maximum, true, ZoneType.BattleZone, ZoneType.Hand)
        {
        }

        protected BounceEffect(BounceEffect effect) : base(effect)
        {
        }
    }
}
