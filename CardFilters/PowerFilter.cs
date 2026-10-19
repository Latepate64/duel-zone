using Interfaces;

namespace CardFilters;

public class PowerFilter : ICardFilter
{
    private readonly int power;

    public PowerFilter(int power)
    {
        this.power = power;
    }

    public PowerFilter(PowerFilter filter)
    {
        power = filter.power;
    }

    public ICardFilter Copy()
    {
        return new PowerFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.Power != power) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PowerFilter filter) return false;
        if (power != filter.power) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return power.GetHashCode();
    }
}
