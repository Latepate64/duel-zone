using Interfaces;

namespace CardFilters;

public class SilentSkillFilter : ICardFilter
{
    public SilentSkillFilter()
    {
    }

    public ICardFilter Copy()
    {
        return new SilentSkillFilter();
    }

    public bool Match(ICard card)
    {
        if (card is not ICreature creature) return false;
        if (!creature.HasSilentSkill) return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SilentSkillFilter) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return typeof(SilentSkillFilter).GetHashCode();
    }
}
