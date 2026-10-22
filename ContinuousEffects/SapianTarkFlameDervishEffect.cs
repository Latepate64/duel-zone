using ContinuousEffects.CanAttackUntappedCreatures;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// This creature gets +4000 power and can attack untapped creatures.
/// </summary>
public sealed class SapianTarkFlameDervishEffect : ThisCreatureCanAttackUntappedCreaturesEffect,
    IPowerModifyingEffect
{
    public SapianTarkFlameDervishEffect(ICardFilter targetFilter) : base(targetFilter)
    {
    }

    public SapianTarkFlameDervishEffect(
        SapianTarkFlameDervishEffect sapianTarkFlameDervishEffect) : base(
            sapianTarkFlameDervishEffect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SapianTarkFlameDervishEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        (Source as ICreature).IncreasePower(4000);
    }
}
