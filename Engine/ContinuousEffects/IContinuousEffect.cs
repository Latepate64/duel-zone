namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : IEffect, ITimestampable
    {
        IContinuousEffect Copy();
    }
}