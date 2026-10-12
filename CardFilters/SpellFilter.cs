using Interfaces;

namespace CardFilters;

public class SpellFilter : ICardFilter
{
    public SpellFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new SpellFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ISpell) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SpellFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(SpellFilter).GetHashCode();
    }
}
