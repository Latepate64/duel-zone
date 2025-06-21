using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureHasSpeedAttackerEffect : ContinuousEffect, ISpeedAttackerEffect
{
    public ThisCreatureHasSpeedAttackerEffect() : base()
    {
    }

    public bool Applies(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasSpeedAttackerEffect();
    }

    public override string ToString()
    {
        return "Speed attacker";
    }
}
