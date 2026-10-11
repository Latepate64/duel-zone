using Interfaces;

namespace CardFilters;

public class EvolutionCreatureFilter : ICardFilter
{
    public EvolutionCreatureFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new EvolutionCreatureFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.IsEvolutionCreature) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EvolutionCreatureFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(EvolutionCreatureFilter).GetHashCode();
    }
}
