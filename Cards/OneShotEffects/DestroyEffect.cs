using OneShotEffects;
using Engine;

namespace Cards.OneShotEffects;

public abstract class DestroyEffect : CardMovingChoiceEffect<Creature>
{
    protected DestroyEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
    {
    }

    protected DestroyEffect(DestroyEffect effect) : base(effect)
    {
    }
}
