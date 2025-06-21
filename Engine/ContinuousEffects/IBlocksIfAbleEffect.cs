namespace Engine.ContinuousEffects
{
    public interface IBlocksIfAbleEffect : IContinuousEffect
    {
        bool BlocksIfAble(Creature blocker, Creature attacker, IGame game);
    }
}
