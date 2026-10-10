using Interfaces;

namespace CardFilters;

public class RaceCreatureFilter : ICardFilter
{
    private readonly Race[] races;

    public RaceCreatureFilter(RaceCreatureFilter filter)
    {
        races = filter.races;
    }

    public RaceCreatureFilter(params Race[] races)
    {
        this.races = races;
    }

    public ICardFilter Copy()
    {
        return new RaceCreatureFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.HasRace(races)) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not RaceCreatureFilter filter) return false;
        if (!races.SequenceEqual(filter.races)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var race in races)
        {
            hash.Add(race);
        }
        return hash.ToHashCode();
    }
}