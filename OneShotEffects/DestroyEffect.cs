using Interfaces;

namespace OneShotEffects;

public abstract class DestroyEffect : CardMovingChoiceEffect<ICreature>
{
    protected DestroyEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
    {
    }

    protected DestroyEffect(DestroyEffect effect) : base(effect)
    {
    }
}
