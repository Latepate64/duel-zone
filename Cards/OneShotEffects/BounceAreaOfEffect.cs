using Common;

namespace Cards.OneShotEffects
{
    abstract class BounceAreaOfEffect : CardMovingAreaOfEffect
    {
        protected BounceAreaOfEffect(BounceAreaOfEffect effect) : base(effect)
        {
        }

        protected BounceAreaOfEffect() : base(ZoneType.BattleZone, ZoneType.Hand)
        {
        }
    }
}
