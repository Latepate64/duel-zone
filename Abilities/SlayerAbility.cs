using Interfaces;

namespace Abilities;

/// <summary>
/// Slayer (Whenever this creature battles, destroy the other creature after the
/// battle.)
/// </summary>
public class SlayerAbility : StaticAbility, ISlayerAbility
{
    public SlayerAbility()
    {
    }

    public SlayerAbility(SlayerAbility ability) : base(ability)
    {
    }

    public bool Applies(ICreature creature, ICard against, IGame game)
    {
        if (creature.Equals(Source)) return true;
        return false;
    }

    public override IAbility Copy()
    {
        return new SlayerAbility(this);
    }
}