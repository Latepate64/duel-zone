namespace Engine.ContinuousEffects
{
    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public interface ICostModifyingEffect : IContinuousEffect
    {
        int GetChange(ICard card);
    }

    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public interface IMinimumCostModifyingEffect : IContinuousEffect
    {
        int GetMinimumCost(ICard card);
    }
}
