using Interfaces;

namespace Abilities;

/// <summary>
/// Civilization blocker (Whenever an opponent's civilization creature attacks,
/// you may tap this creature to stop the attack. Then the 2 creatures battle.)
/// </summary>
public class CivilizationBlockerAbility : StaticAbility, IBlockerAbility
{
    private readonly Civilization[] civilizations;

    public CivilizationBlockerAbility(params Civilization[] civilizations)
    {
        this.civilizations = civilizations;
    }

    public CivilizationBlockerAbility(
        CivilizationBlockerAbility ability) : base(ability)
    {
        civilizations = [..ability.civilizations];
    }

    public bool CanBlock(ICreature blocker, ICreature attacker)
    {
        if (!blocker.Equals(Source)) return false;
        if (!attacker.HasCivilization(civilizations)) return false;
        return true;
    }

    public override IAbility Copy()
    {
        return new CivilizationBlockerAbility(this);
    }
}