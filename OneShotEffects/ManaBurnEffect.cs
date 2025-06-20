using Engine;

namespace OneShotEffects;

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
