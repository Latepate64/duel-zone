using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class BounceAreaOfEffect : CardMovingAreaOfEffect
    {
        public BounceAreaOfEffect(BounceAreaOfEffect effect) : base(effect)
        {
        }

        public BounceAreaOfEffect(CardFilter filter) : base(ZoneType.BattleZone, ZoneType.Hand, filter)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BounceAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Return each {Filter} to its owner's hand.";
        }
    }
}
