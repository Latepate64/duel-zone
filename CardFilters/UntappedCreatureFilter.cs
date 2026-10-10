using Interfaces;

namespace CardFilters;

public class UntappedCreatureFilter : ICardFilter
{
    public UntappedCreatureFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new UntappedCreatureFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.Tapped) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UntappedCreatureFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(UntappedCreatureFilter).GetHashCode();
    }
}
