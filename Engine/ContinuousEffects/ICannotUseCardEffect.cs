namespace Engine.ContinuousEffects
{
    public interface ICannotUseCardEffect : IContinuousEffect
    {
        bool Applies(ICard card);
    }
}
