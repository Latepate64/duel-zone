using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureHasSpeedAttackerEffect : ContinuousEffect, ISpeedAttackerEffect
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
