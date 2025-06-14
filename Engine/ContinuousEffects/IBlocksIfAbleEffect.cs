namespace Engine.ContinuousEffects
{
    public interface IBlocksIfAbleEffect : IContinuousEffect
    {
        bool BlocksIfAble(Card blocker, Card attacker, IGame game);
    }
}
