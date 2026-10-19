using Interfaces;

namespace CardFilters;

public class TappedCardFilter : ICardFilter
{
    public TappedCardFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new TappedCardFilter();
    }

    public bool Match(ICard card)
    {
        if (!card.Tapped) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TappedCardFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(TappedCardFilter).GetHashCode();
    }
}
