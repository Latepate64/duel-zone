using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TottoPipicchiEffect : ContinuousEffect, ISpeedAttackerEffect
{
    public TottoPipicchiEffect() : base()
    {
    }

    public bool Applies(ICreature creature, IGame game)
    {
        return creature.IsDragon;
    }

    public override IContinuousEffect Copy()
    {
        return new TottoPipicchiEffect();
    }

    public override string ToString()
    {
        return "Each creature in the battle zone that has Dragon in its race has \"speed attacker.\"";
    }
}
