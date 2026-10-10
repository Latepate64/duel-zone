using Interfaces;

namespace CardFilters;

public class NonCivilizationCreatureFilter : ICardFilter
{
    private readonly Civilization[] civilizations;

    public NonCivilizationCreatureFilter(NonCivilizationCreatureFilter filter)
    {
        civilizations = filter.civilizations;
    }

    public NonCivilizationCreatureFilter(params Civilization[] civilizations)
    {
        this.civilizations = civilizations;
    }

    public ICardFilter Copy()
    {
        return new NonCivilizationCreatureFilter(this);
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (creature.HasCivilization(civilizations)) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not NonCivilizationCreatureFilter filter) return false;
        if (!civilizations.SequenceEqual(filter.civilizations)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var civ in civilizations)
        {
            hash.Add(civ);
        }
        return hash.ToHashCode();
    }
}