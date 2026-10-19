using Interfaces;

namespace CardFilters;

public class MaxCostCreatureFilter : ICardFilter
{
    private readonly int maxCost;

    public MaxCostCreatureFilter(int maxCost)
    {
        this.maxCost = maxCost;
    }

    public MaxCostCreatureFilter(MaxCostCreatureFilter filter)
    {
        maxCost = filter.maxCost;
    }

    public ICardFilter Copy()
    {
        return new MaxCostCreatureFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.ManaCost > maxCost) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MaxCostCreatureFilter filter) return false;
        if (maxCost != filter.maxCost) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return maxCost.GetHashCode();
    }
}
