using Interfaces;

namespace CardFilters;

public class NameFilter : ICardFilter
{
    private readonly string name;

    public NameFilter(NameFilter filter)
    {
        name = filter.name;
    }

    public NameFilter(string name)
    {
        this.name = name;
    }

    public ICardFilter Copy()
    {
        return new NameFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card.Name != name) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not NameFilter filter) return false;
        if (!name.SequenceEqual(filter.name)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}