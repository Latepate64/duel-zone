namespace Engine.ContinuousEffects
{
    public interface IBlockerEffect : IContinuousEffect
    {
        bool CanBlock(ICard blocker, ICard attacker, IGame game);
    }
}
