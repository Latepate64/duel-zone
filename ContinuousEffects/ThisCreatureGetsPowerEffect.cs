using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable
{
    public ThisCreatureGetsPowerEffect(ThisCreatureGetsPowerEffect effect) : base(effect)
    {
        Power = effect.Power;
    }

    public ThisCreatureGetsPowerEffect(int power) : base()
    {
        Power = power;
    }

    public int Power { get; }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        (Source as ICreature).IncreasePower(Power);
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power.";
    }
}
