namespace Engine.ContinuousEffects
{
    public interface IBlockerEffect : IContinuousEffect
    {
        bool CanBlock(Card blocker, Card attacker, IGame game);
    }
}
