using Interfaces;

namespace CardFilters;

public class MinCostCreatureFilter : ICardFilter
{
    private readonly int minCost;

    public MinCostCreatureFilter(int minCost)
    {
        this.minCost = minCost;
    }

    public MinCostCreatureFilter(MinCostCreatureFilter filter)
    {
        minCost = filter.minCost;
    }

    public ICardFilter Copy()
    {
        return new MinCostCreatureFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.ManaCost < minCost) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MinCostCreatureFilter filter) return false;
        if (minCost != filter.minCost) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return minCost.GetHashCode();
    }
}
