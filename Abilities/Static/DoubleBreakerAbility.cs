using Interfaces;
using Interfaces.Zones;

namespace Abilities.Static;

/// <summary>
/// Double breaker (This creature breaks 2 shields.)
/// </summary>
public sealed class DoubleBreakerAbility : StaticAbility, IBreakerAbility
{
    public DoubleBreakerAbility() : base()
    {
    }

    public DoubleBreakerAbility(DoubleBreakerAbility effect) : base(effect)
    {
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!creature.Equals(Source)) return 1;
        return 2;
    }

    public override IAbility Copy()
    {
        return new DoubleBreakerAbility(this);
    }
}
