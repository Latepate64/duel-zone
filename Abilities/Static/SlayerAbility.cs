using CardFilters;
using Interfaces;

namespace Abilities.Static;

/// <summary>
/// Slayer (Whenever this creature battles, destroy the other creature after the
/// battle.)
/// </summary>
public class SlayerAbility : StaticAbility, ISlayerAbility
{
    private readonly ICardFilter defendingCreatureFilter;

    public SlayerAbility() : this(new AnyCardFilter())
    {
    }

    public SlayerAbility(ICardFilter defendingCreatureFilter)
    {
        this.defendingCreatureFilter = defendingCreatureFilter;
    }

    public SlayerAbility(SlayerAbility ability) : base(ability)
    {
        defendingCreatureFilter = ability.defendingCreatureFilter.Copy();
    }

    public bool Applies(ICreature creature, ICreature defendingCreature)
    {
        if (!creature.Equals(Source)) return false;
        if (!defendingCreatureFilter.Match(defendingCreature)) return false;
        return true;
    }

    public override IAbility Copy()
    {
        return new SlayerAbility(this);
    }
}