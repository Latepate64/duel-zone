using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for a Duel Masters creature.
    /// </summary>
    public interface ICreature : ICard
    {
        /// <summary>
        /// The base power of creature.
        /// </summary>
        int Power { get; }

        /// <summary>
        /// Race is a characteristic of a creature.
        /// </summary>
        ReadOnlyCollection<string> Races { get; }

        /// <summary>
        /// Summoning sickness limits when a creature is able to attack.
        /// </summary>
        bool SummoningSickness { get; }
    }
}
