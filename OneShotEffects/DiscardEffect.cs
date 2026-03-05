using Interfaces;

namespace OneShotEffects;

public abstract class DiscardEffect : CardMovingChoiceEffect<ICard>
{
    protected DiscardEffect(DiscardEffect effect) : base(effect)
    {
    }

    protected DiscardEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.Hand, ZoneType.Graveyard)
    {
    }
}
