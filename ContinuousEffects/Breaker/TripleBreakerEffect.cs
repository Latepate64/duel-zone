using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

public sealed class TripleBreakerEffect : ContinuousEffect, IBreakerEffect
{
    public TripleBreakerEffect() : base()
    {
    }

    public TripleBreakerEffect(TripleBreakerEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new TripleBreakerEffect(this);
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        return IsSourceOfAbility(creature) ? 3 : 1;
    }
}

