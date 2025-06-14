namespace Engine.ContinuousEffects
{
    public interface ISlayerEffect : IContinuousEffect
    {
        bool Applies(Card creature, Card against, IGame game);
    }
}
