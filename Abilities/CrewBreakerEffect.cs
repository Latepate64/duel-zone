using Interfaces;
using Interfaces.Zones;

namespace Abilities;

public abstract class CrewBreakerAbility : StaticAbility, IBreakerAbility
{
    protected CrewBreakerAbility(CrewBreakerAbility effect) : base(effect)
    {
    }

    protected CrewBreakerAbility() : base()
    {
        
    }

    public abstract int GetAmount(ICreature creature, IBattleZone battleZone);
}
