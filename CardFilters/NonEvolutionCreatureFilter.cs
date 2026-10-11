using Interfaces;

namespace CardFilters;

public class NonEvolutionCreatureFilter : ICardFilter
{
    public NonEvolutionCreatureFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new NonEvolutionCreatureFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.IsNonEvolutionCreature) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not NonEvolutionCreatureFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(NonEvolutionCreatureFilter).GetHashCode();
    }
}
