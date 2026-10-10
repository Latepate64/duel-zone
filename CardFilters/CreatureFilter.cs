using Interfaces;

namespace CardFilters;

public class CreatureFilter : ICardFilter
{
    public CreatureFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new CreatureFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not CreatureFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(CreatureFilter).GetHashCode();
    }
}
