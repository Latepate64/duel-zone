using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects;

public abstract class PowerModifyingMultiplierEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable
{
    protected PowerModifyingMultiplierEffect(int power) : base()
    {
        Power = power;
    }

    protected PowerModifyingMultiplierEffect(PowerModifyingMultiplierEffect effect) : base(effect)
    {
        Power = effect.Power;
    }

    public int Power { get; }

    public virtual void ModifyPower(IGame game)
    {
        (Source as Creature).IncreasePower(GetMultiplier(game) * Power);
    }

    protected abstract int GetMultiplier(IGame game);
}
