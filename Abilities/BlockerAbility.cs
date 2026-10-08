using Interfaces;

namespace Abilities;

/// <summary>
/// Blocker (Whenever an opponent's creature attacks, you may tap this creature
/// to stop the attack. Then the 2 creatures battle.)
/// </summary>
public class BlockerAbility : StaticAbility, IBlockerAbility
{
    public BlockerAbility()
    {
    }

    public BlockerAbility(BlockerAbility continuousEffect) : base(
        continuousEffect)
    {
    }

    public bool CanBlock(ICreature blocker, ICreature attacker)
    {
        if (blocker.Equals(Source)) return true;
        return false;
    }

    public override IAbility Copy()
    {
        return new BlockerAbility(this);
    }
}