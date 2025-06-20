using OneShotEffects;
using Engine;

namespace Cards.OneShotEffects;

public abstract class ManaRecoveryEffect : CardMovingChoiceEffect<Card>
{
    protected ManaRecoveryEffect(ManaRecoveryEffect effect) : base(effect)
    {
    }

    protected ManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Hand)
    {
    }
}
