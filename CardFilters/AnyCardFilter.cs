using Interfaces;

namespace CardFilters;

public class AnyCardFilter : ICardFilter
{
    public AnyCardFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new AnyCardFilter();
    }

    public bool Match(ICard card)
    {
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not AnyCardFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(AnyCardFilter).GetHashCode();
    }
}
