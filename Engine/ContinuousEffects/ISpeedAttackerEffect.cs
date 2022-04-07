namespace Engine.ContinuousEffects
{
    public interface ISpeedAttackerEffect : IContinuousEffect
    {
        bool Applies(ICard creature, IGame game);
    }
}
