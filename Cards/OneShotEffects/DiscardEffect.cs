using OneShotEffects;
using Engine;

namespace Cards.OneShotEffects;

public abstract class DiscardEffect : CardMovingChoiceEffect<Card>
{
    protected DiscardEffect(DiscardEffect effect) : base(effect)
    {
    }

    protected DiscardEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.Hand, ZoneType.Graveyard)
    {
    }
}
