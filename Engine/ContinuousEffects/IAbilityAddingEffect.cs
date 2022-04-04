namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 613.1f
    /// Layer 6: Ability-adding effects are applied.
    /// </summary>
    public interface IAbilityAddingEffect : IContinuousEffect
    {
        /// <summary>
        /// 613.1f
        /// Layer 6: Ability-adding effects are applied.
        /// </summary>
        void AddAbility(IGame game);
    }
}
