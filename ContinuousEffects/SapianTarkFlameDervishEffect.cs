using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SapianTarkFlameDervishEffect : ThisCreatureCanAttackUntappedCreaturesEffect, IPowerModifyingEffect
{
    public override IContinuousEffect Copy()
    {
        return new SapianTarkFlameDervishEffect();
    }

    public void ModifyPower(IGame game)
    {
        (Source as ICreature).IncreasePower(4000);
    }

    public override string ToString()
    {
        return "This creature gets +4000 power and can attack untapped creatures.";
    }
}
