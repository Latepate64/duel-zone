using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// Triple breaker (This creature breaks 3 shields.)
/// </summary>
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
        if (!IsSourceOfAbility(creature)) return 1;
        return 3;
    }
}

