using Interfaces;

namespace CardFilters;

public class BlockerFilter : ICardFilter
{
    public BlockerFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new BlockerFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.HasBlocker) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BlockerFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(BlockerFilter).GetHashCode();
    }
}
