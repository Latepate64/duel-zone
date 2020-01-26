using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Represents a creature that exists in battle zone.
    /// </summary>
    public class BattleZoneCreature : BattleZoneCard, IBattleZoneCreature
    {
        /// <summary>
        /// Determines whether the creature is tapped or untapped.
        /// </summary>
        public bool Tapped { get; internal set; }

        /// <summary>
        /// Power of the creature.
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Races the creature has.
        /// </summary>
        public ReadOnlyCollection<string> Races { get; }

        /// <summary>
        /// Determines whether the creature has summoning sickess.
        /// </summary>
        public bool SummoningSickness { get; internal set; } = true;

        /// <summary>
        /// Creates a battle zone creature.
        /// </summary>
        /// <param name="card"></param>
        public BattleZoneCreature(ICard card) : base(card ?? throw new System.ArgumentNullException(nameof(card)))
        {
        }
    }
}
