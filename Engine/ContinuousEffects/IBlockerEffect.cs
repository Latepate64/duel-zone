namespace Engine.ContinuousEffects
{
    public interface IBlockerEffect : IContinuousEffect
    {
        bool Applies(ICard blocker, ICard attacker, IGame game);
    }
}
