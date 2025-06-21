namespace Interfaces.ContinuousEffects
{
    public interface IBlocksIfAbleEffect : IContinuousEffect
    {
        bool BlocksIfAble(ICreature blocker, ICreature attacker, IGame game);
    }
}
