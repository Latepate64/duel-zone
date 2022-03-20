namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 613.4c
    /// Layer 7c: Effects that modify power (but don’t set power to a specific number or value) are applied.
    /// </summary>
    public interface IPowerModifyingEffect
    {
        /// <summary>
        /// 613.4c
        /// Layer 7c: Effects that modify power (but don’t set power to a specific number or value) are applied.
        /// </summary>
        void ModifyPower(IGame game);
    }
}
