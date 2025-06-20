using OneShotEffects;
using Engine;

namespace Cards.OneShotEffects;

public abstract class ManaBurnEffect : CardMovingChoiceEffect<Card>
{
    protected ManaBurnEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
    {
    }

    protected ManaBurnEffect(ManaBurnEffect effect) : base(effect)
    {
    }
}
