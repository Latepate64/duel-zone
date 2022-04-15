using Engine;

namespace Cards.OneShotEffects
{
    abstract class ManaRecoveryEffect : CardMovingChoiceEffect
    {
        protected ManaRecoveryEffect(ManaRecoveryEffect effect) : base(effect)
        {
        }

        protected ManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Hand)
        {
        }
    }
}
