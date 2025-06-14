namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : IEffect
    {
        int Timestamp { get; set; }
        IContinuousEffect Copy();
    }
}