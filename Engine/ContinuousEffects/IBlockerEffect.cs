namespace Engine.ContinuousEffects
{
    public interface IBlockerEffect : IContinuousEffect
    {
        bool CanBlock(ICreature blocker, ICreature attacker, IGame game);
    }
}
