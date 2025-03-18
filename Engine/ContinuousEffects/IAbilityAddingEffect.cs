namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 113.10.
    /// An effect that adds an ability to a card.
    /// </summary>
    public interface IAbilityAddingEffect : IContinuousEffect
    {
        /// <summary>
        /// 113.10. Adds an ability to a card.
        /// </summary>
        /// <param name="game">A Duel Masters game.</param>
        void AddAbility(IGame game);
    }
}
