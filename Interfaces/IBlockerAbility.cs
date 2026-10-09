namespace Interfaces;

public interface IBlockerAbility : IStaticAbility
{
    bool CanBlock(ICreature blocker, ICreature attacker);
}