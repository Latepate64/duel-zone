using DuelMastersModels.Abilities.TriggeredAbilities;
using System.Collections.Generic;

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
        ICollection<Race> Races { get; }

        ICollection<TriggeredAbility> TriggerAbilities { get; }
    }
}
