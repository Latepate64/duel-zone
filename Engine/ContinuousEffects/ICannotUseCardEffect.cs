namespace Engine.ContinuousEffects
{
    public interface ICannotUseCardEffect : IContinuousEffect
    {
        bool Applies(IGame game);
    }
}
