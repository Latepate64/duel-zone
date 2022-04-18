namespace Engine.ContinuousEffects
{
    public interface IBlocksIfAbleEffect : IContinuousEffect
    {
        bool BlocksIfAble(ICard blocker, ICard attacker, IGame game);
    }
}
