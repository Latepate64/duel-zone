using Interfaces;

namespace CardFilters;

public class TappedCreatureFilter : ICardFilter
{
    public TappedCreatureFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new TappedCreatureFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.Tapped) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TappedCreatureFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(TappedCreatureFilter).GetHashCode();
    }
}
