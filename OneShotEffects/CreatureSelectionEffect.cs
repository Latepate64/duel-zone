using Engine;

namespace OneShotEffects;

public abstract class CreatureSelectionEffect : CardSelectionEffect<Creature>
{
    protected CreatureSelectionEffect(CreatureSelectionEffect effect) : base(effect)
    {
    }

    protected CreatureSelectionEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum,
        controllerChooses)
    {
    }
}
