using Interfaces;
using Interfaces.Zones;

namespace Abilities.Static;

public class CrewBreakerAbility : StaticAbility, IBreakerAbility
{
    private readonly ICardFilter filter;

    public CrewBreakerAbility(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public CrewBreakerAbility(CrewBreakerAbility effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!creature.Equals(Source)) return 1;
        return 1 + battleZone.GetNumberOfOtherCreaturesControllerByPlayer(
            creature, filter);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CrewBreakerAbility ability) return false;
        if (!filter.Equals(ability.filter)) return false;
        return true;
        
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(filter);
    }

    public override IAbility Copy()
    {
        return new CrewBreakerAbility(this);
    }
}
