using Engine;

namespace Cards.OneShotEffects
{
    abstract class ManaRecoveryAreaOfEffect : CardMovingAreaOfEffect
    {
        protected ManaRecoveryAreaOfEffect(ManaRecoveryAreaOfEffect effect) : base(effect)
        {
        }

        protected ManaRecoveryAreaOfEffect() : base(ZoneType.ManaZone, ZoneType.Hand)
        {
        }
    }
}
