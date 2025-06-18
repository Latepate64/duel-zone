namespace Engine.ContinuousEffects
{
    public interface ISlayerEffect : IContinuousEffect
    {
        bool Applies(Creature creature, Card against, IGame game);
    }
}
