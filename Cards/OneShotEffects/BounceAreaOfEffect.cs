using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class BounceAreaOfEffect : CardMovingAreaOfEffect
    {
        protected BounceAreaOfEffect(BounceAreaOfEffect effect) : base(effect)
        {
        }

        protected BounceAreaOfEffect(CardFilter filter) : base(ZoneType.BattleZone, ZoneType.Hand, filter)
        {
        }
    }
}
