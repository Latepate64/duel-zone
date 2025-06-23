using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SeniaOrchardAvengerEffect : GetPowerAndDoubleBreakerEffect
{
    public SeniaOrchardAvengerEffect() : base(5000)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SeniaOrchardAvengerEffect();
    }

    public override string ToString()
    {
        return "This creature gets +5000 power and has \"double breaker\".";
    }

    protected override List<ICreature> GetAffectedCards(IGame game)
    {
        return [Source as ICreature];
    }
}
