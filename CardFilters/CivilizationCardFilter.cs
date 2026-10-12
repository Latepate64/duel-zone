using Interfaces;

namespace CardFilters;

public class CivilizationCardFilter : ICardFilter
{
    private readonly Civilization[] civilizations;

    public CivilizationCardFilter(CivilizationCardFilter filter)
    {
        civilizations = filter.civilizations;
    }

    public CivilizationCardFilter(params Civilization[] civilizations)
    {
        this.civilizations = civilizations;
    }

    public ICardFilter Copy()
    {
        return new CivilizationCardFilter(this);
    }

    public bool Match(ICard card)
    {
        if (!card.HasCivilization(civilizations)) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not CivilizationCardFilter filter) return false;
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