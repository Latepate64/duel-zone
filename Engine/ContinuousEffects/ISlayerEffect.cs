namespace Engine.ContinuousEffects
{
    public interface ISlayerEffect : IContinuousEffect
    {
        bool Applies(ICard creature, ICard against, IGame game);
    }
}
