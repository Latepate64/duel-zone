using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

public sealed class CreaturesGetPowerEffect : ContinuousEffect, IPowerModifyingEffect
{
    private readonly int power;
    private readonly ICreature[] creatures;

    public CreaturesGetPowerEffect(CreaturesGetPowerEffect effect) : base(effect)
    {
        power = effect.power;
        creatures = effect.creatures;
    }

    public CreaturesGetPowerEffect(int power, params ICreature[] creatures) : base()
    {
        this.power = power;
        this.creatures = creatures;
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesGetPowerEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        creatures.ToList().ForEach(x => x.IncreasePower(power));
    }
}
