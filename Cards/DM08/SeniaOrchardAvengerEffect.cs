using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM08;

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
