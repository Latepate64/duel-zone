using Interfaces;

namespace CardFilters;

public class MultiColoredCreatureFilter : ICardFilter
{
    public MultiColoredCreatureFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new MultiColoredCreatureFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.IsMultiColored) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MultiColoredCreatureFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(MultiColoredCreatureFilter).GetHashCode();
    }
}
