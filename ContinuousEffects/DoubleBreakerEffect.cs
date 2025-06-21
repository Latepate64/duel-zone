using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class DoubleBreakerEffect : ContinuousEffect, IBreakerEffect
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

    public int GetAmount(IGame game, ICreature creature)
    {
        return IsSourceOfAbility(creature) ? 2 : 1;
    }

    public override string ToString()
    {
        return "Double breaker";
    }
}
