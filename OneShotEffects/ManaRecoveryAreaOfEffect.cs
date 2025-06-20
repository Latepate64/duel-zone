using Engine;

namespace OneShotEffects;

public abstract class ManaRecoveryAreaOfEffect : CardMovingAreaOfEffect
{
    protected ManaRecoveryAreaOfEffect(ManaRecoveryAreaOfEffect effect) : base(effect)
    {
    }

    protected ManaRecoveryAreaOfEffect() : base(ZoneType.ManaZone, ZoneType.Hand)
    {
    }
}
