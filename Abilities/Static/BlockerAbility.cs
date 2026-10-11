using Interfaces;

namespace Abilities.Static;

/// <summary>
/// Blocker (Whenever an opponent's creature attacks, you may tap this creature
/// to stop the attack. Then the 2 creatures battle.)
/// </summary>
public class BlockerAbility : StaticAbility, IBlockerAbility
{
    private readonly ICardFilter? attackerFilter;

    public BlockerAbility()
    {
    }

    public BlockerAbility(ICardFilter attackerFilter)
    {
        this.attackerFilter = attackerFilter;
    }

    public BlockerAbility(BlockerAbility ability) : base(ability)
    {
        attackerFilter = ability.attackerFilter?.Copy();
    }

    public bool CanBlock(ICreature blocker, ICreature attacker)
    {
        if (!blocker.Equals(Source)) return false;
        if (attackerFilter == null) return true;
        if (!attackerFilter.Match(attacker)) return false;
        return true;
    }

    public override IAbility Copy()
    {
        return new BlockerAbility(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not BlockerAbility ability) return false;
        if (attackerFilter == null &&
            ability.attackerFilter != null) return false;
        if (attackerFilter != null &&
            !attackerFilter.Equals(ability.attackerFilter)) return false;
        return true;
        
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(attackerFilter);
    }
}
