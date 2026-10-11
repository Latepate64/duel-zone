using Interfaces;

namespace CardFilters;

public class MultiFilter : ICardFilter
{
    private readonly ICardFilter[] filters;

    public MultiFilter(params ICardFilter[] filters)
    {
        this.filters = filters;
    }

    public MultiFilter(MultiFilter filter)
    {
        filters = [..filter.filters.Select(x => x.Copy())];
    }


    public ICardFilter Copy()
    {
        return new MultiFilter(this);
    }

    public bool Match(ICard card)
    {
        return filters.All(x => x.Match(card));
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MultiFilter multi) return false;
        if (!filters.SequenceEqual(multi.filters)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var filter in filters)
        {
            hash.Add(filter);
        }
        return hash.ToHashCode();
    }
}