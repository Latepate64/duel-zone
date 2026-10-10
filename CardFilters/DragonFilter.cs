using Interfaces;

namespace CardFilters;

public class DragonFilter : ICardFilter
{
    public DragonFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new DragonFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.IsDragon) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DragonFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(DragonFilter).GetHashCode();
    }
}
