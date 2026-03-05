using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class AsraVizierOfSafetyEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
{
    public AsraVizierOfSafetyEffect() : base() { }

    public AsraVizierOfSafetyEffect(AsraVizierOfSafetyEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        Source.AddGrantedAbility(new StaticAbility(new ThisCreatureHasBlockerEffect()));
    }

    public override IContinuousEffect Copy()
    {
        return new AsraVizierOfSafetyEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        (Source as ICreature).IncreasePower(4000);
    }

    public override string ToString()
    {
        return "This creature gets +4000 power and has \"Blocker.\"";
    }
}
