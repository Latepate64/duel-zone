using Interfaces;

namespace OneShotEffects;

public abstract class CreatureSelectionEffect : CardSelectionEffect<ICreature>
{
    protected CreatureSelectionEffect(CreatureSelectionEffect effect) : base(effect)
    {
    }

    protected CreatureSelectionEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum,
        controllerChooses)
    {
    }
}
