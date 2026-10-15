using Interfaces;

namespace CardFilters;

public class NonNameFilter : ICardFilter
{
    private readonly string name;

    public NonNameFilter(NonNameFilter filter)
    {
        name = filter.name;
    }

    public NonNameFilter(string name)
    {
        this.name = name;
    }

    public ICardFilter Copy()
    {
        return new NonNameFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card.Name == name) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not NonNameFilter filter) return false;
        if (!name.SequenceEqual(filter.name)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}