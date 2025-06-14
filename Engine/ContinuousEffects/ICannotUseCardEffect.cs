namespace Engine.ContinuousEffects
{
    public interface ICannotUseCardEffect : IContinuousEffect
    {
        bool Applies(Card card, IGame game);
    }
}
