using Interfaces;

namespace Abilities.Static;

/// <summary>
/// Civilization slayer (Whenever this creature battles a civilization creature,
/// destroy the other creature after the battle.)
/// </summary>
public class CivilizationSlayerAbility : StaticAbility, ISlayerAbility
{
    private readonly Civilization[] civilizations;

    public CivilizationSlayerAbility(params Civilization[] civilizations)
    {
        this.civilizations = civilizations;
    }

    public CivilizationSlayerAbility(CivilizationSlayerAbility ability) : base(
        ability)
    {
        civilizations = [..ability.civilizations];
    }

    public bool Applies(ICreature creature, ICreature against)
    {
        if (!creature.Equals(Source)) return false;
        if (!against.HasCivilization(civilizations)) return false;
        return true;
    }

    public override IAbility Copy()
    {
        return new CivilizationSlayerAbility(this);
    }
}