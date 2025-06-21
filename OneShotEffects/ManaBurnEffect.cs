using Engine;
using Interfaces;

namespace OneShotEffects;

public abstract class ManaBurnEffect : CardMovingChoiceEffect<ICard>
{
    protected ManaBurnEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
    {
    }

    protected ManaBurnEffect(ManaBurnEffect effect) : base(effect)
    {
    }
}
