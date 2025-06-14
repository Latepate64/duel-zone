namespace Engine.ContinuousEffects
{
    public interface ISpeedAttackerEffect : IContinuousEffect
    {
        bool Applies(Card creature, IGame game);
    }
}
