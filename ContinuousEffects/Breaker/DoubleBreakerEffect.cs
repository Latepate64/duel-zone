using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// Double breaker (This creature breaks 2 shields.)
/// </summary>
public sealed class DoubleBreakerEffect : ContinuousEffect, IBreakerEffect
{
    public DoubleBreakerEffect() : base()
    {
    }

    public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new DoubleBreakerEffect(this);
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(creature)) return 1;
        return 2;
    }
}
