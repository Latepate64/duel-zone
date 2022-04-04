namespace Engine.ContinuousEffects
{
    public interface ISlayerEffect : IContinuousEffect
    {
        bool Applies(ICard against);
    }
}
