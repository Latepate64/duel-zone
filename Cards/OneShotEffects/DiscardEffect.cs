using Common;

namespace Cards.OneShotEffects
{
    abstract class DiscardEffect : CardMovingChoiceEffect
    {
        protected DiscardEffect(DiscardEffect effect) : base(effect)
        {
        }

        protected DiscardEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.Hand, ZoneType.Graveyard)
        {
        }
    }
}
