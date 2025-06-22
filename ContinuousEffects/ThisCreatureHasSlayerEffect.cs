using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureHasSlayerEffect : ContinuousEffect, ISlayerEffect
{
    public ThisCreatureHasSlayerEffect(ThisCreatureHasSlayerEffect effect) : base(effect)
    {
    }

    public ThisCreatureHasSlayerEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasSlayerEffect();
    }

    public override string ToString()
    {
        return "Slayer";
    }

    public bool Applies(ICreature creature, ICard against, IGame game)
    {
        return IsSourceOfAbility(creature);
    }
}