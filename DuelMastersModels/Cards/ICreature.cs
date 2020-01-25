using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for Duel Masters creatures.
    /// </summary>
    public interface ICreature : ICard
    {
        /// <summary>
        /// The base power of creature. Use Duel's method GetPower(creature) in order to get the actual power of a creature.
        /// </summary>
        int Power { get; }

        /// <summary>
        /// Race is a characteristic of a creature.
        /// </summary>
        ReadOnlyCollection<string> Races { get; }
    }
}
