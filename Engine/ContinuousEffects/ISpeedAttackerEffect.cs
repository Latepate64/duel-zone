namespace Engine.ContinuousEffects
{
    public interface ISpeedAttackerEffect : IContinuousEffect
    {
        bool Applies(Creature creature, IGame game);
    }
}
