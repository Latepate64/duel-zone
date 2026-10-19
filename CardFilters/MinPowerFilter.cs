using Interfaces;

namespace CardFilters;

public class MinPowerFilter : ICardFilter
{
    private readonly int minPower;

    public MinPowerFilter(int minPower)
    {
        this.minPower = minPower;
    }

    public MinPowerFilter(MinPowerFilter filter)
    {
        minPower = filter.minPower;
    }

    public ICardFilter Copy()
    {
        return new MinPowerFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.Power < minPower) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MinPowerFilter filter) return false;
        if (minPower != filter.minPower) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return minPower.GetHashCode();
    }
}
