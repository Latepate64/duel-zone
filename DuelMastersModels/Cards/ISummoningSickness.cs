namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for cards that contain information of summoning sickness.
    /// </summary>
    public interface ISummoningSickness
    {
        /// <summary>
        /// Summoning sickness limits when a creature is able to attack.
        /// </summary>
        bool SummoningSickness { get; }
    }
}
