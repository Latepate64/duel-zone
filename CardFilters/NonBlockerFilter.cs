using Interfaces;

namespace CardFilters;

public class NonBlockerFilter : ICardFilter
{
    public NonBlockerFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new NonBlockerFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.HasBlocker) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not NonBlockerFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(NonBlockerFilter).GetHashCode();
    }
}
