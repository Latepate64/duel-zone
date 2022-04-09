namespace Engine.ContinuousEffects
{
    public interface IUnchoosableEffect : IContinuousEffect
    {
        bool Applies(ICard creature, IGame game);
    }
}
