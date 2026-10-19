using Interfaces;

namespace CardFilters;

public class WaveStrikerFilter : ICardFilter
{
    public WaveStrikerFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new WaveStrikerFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.HasWaveStriker) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not WaveStrikerFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(WaveStrikerFilter).GetHashCode();
    }
}
