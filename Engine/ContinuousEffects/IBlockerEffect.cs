namespace Engine.ContinuousEffects
{
    public interface IBlockerEffect : IContinuousEffect
    {
        bool Applies(ICard attacker, IGame game);
    }
}
