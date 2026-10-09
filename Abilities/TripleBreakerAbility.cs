using Interfaces;
using Interfaces.Zones;

namespace Abilities;

/// <summary>
/// Triple breaker (This creature breaks 3 shields.)
/// </summary>
public sealed class TripleBreakerAbility : StaticAbility, IBreakerAbility
{
    public TripleBreakerAbility() : base()
    {
    }

    public TripleBreakerAbility(TripleBreakerAbility effect) : base(effect)
    {
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!creature.Equals(Source)) return 1;
        return 3;
    }

    public override IAbility Copy()
    {
        return new TripleBreakerAbility(this);
    }
}
