using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class NinjaPumpkinEffect : ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect,
    IPowerModifyingEffect
{
    public NinjaPumpkinEffect(int blockerMaxPower = 5000) : base(blockerMaxPower)
    {
    }

    public NinjaPumpkinEffect(NinjaPumpkinEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new NinjaPumpkinEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        (Source as Creature).IncreasePower(4000);
    }

    public override string ToString()
    {
        return $"This creature gets +4000 power and can't be blocked by any creature that has power {Power} or less.";
    }
}
