using Interfaces;

namespace CardFilters;

public class MaxPowerFilter : ICardFilter
{
    private readonly int maxPower;

    public MaxPowerFilter(int maxPower)
    {
        this.maxPower = maxPower;
    }

    public MaxPowerFilter(MaxPowerFilter filter)
    {
        maxPower = filter.maxPower;
    }

    public ICardFilter Copy()
    {
        return new MaxPowerFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.Power > maxPower) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MaxPowerFilter filter) return false;
        if (maxPower != filter.maxPower) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return maxPower.GetHashCode();
    }
}
