namespace Engine.ContinuousEffects
{
    /// <summary>
    /// TODO: Apply in engine
    /// </summary>
    public interface ICostModifyingEffect : IContinuousEffect
    {
        int GetChange(ICard card, IGame game);
    }
}
