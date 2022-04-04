namespace Engine.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool Applies(ICard blocker, IGame game);
    }
}
