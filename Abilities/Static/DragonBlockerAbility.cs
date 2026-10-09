using Interfaces;

namespace Abilities.Static;

/// <summary>
/// Dragon blocker (Whenever an opponent's creature that has Dragon in its race
/// attacks, you may tap this creature to stop the attack. Then the 2 creatures
/// battle.)
/// </summary>
public class DragonBlockerAbility : StaticAbility, IBlockerAbility
{
    public DragonBlockerAbility()
    {
    }

    public DragonBlockerAbility(DragonBlockerAbility ability) : base(ability)
    {
    }

    public bool CanBlock(ICreature blocker, ICreature attacker)
    {
        if (!blocker.Equals(Source)) return false;
        if (!attacker.IsDragon) return false;
        return true;
    }

    public override IAbility Copy()
    {
        return new DragonBlockerAbility (this);
    }
}