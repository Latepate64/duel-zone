namespace Engine.ContinuousEffects
{
    public interface IBlocksIfAbleEffect : IContinuousEffect
    {
        bool Applies(ICard creature, IGame game);
    }
}
