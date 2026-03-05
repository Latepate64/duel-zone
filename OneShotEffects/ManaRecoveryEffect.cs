using Interfaces;

namespace OneShotEffects;

public abstract class ManaRecoveryEffect : CardMovingChoiceEffect<ICard>
{
    protected ManaRecoveryEffect(ManaRecoveryEffect effect) : base(effect)
    {
    }

    protected ManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Hand)
    {
    }
}
