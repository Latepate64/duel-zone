namespace Engine.ContinuousEffects
{
    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public interface ICostModifyingEffect : IContinuousEffect
    {
        int GetChange(Card card, IGame game);
    }

    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public interface IMinimumCostModifyingEffect : IContinuousEffect
    {
        int GetMinimumCost(Card card, IGame game);
    }
}
