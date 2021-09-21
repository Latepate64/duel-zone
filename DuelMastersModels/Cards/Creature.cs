using DuelMastersModels.Abilities.TriggeredAbilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public enum Race
    {
        ArmoredDragon,
        EarthDragon,
        LiquidPeople,
    }

    /// <summary>
    /// Creature is a card type.
    /// </summary>
    public abstract class Creature : Card
    {
        /// <summary>
        /// The base power of creature. Use Duel's method GetPower(creature) in order to get the actual power of a creature.
        /// </summary>
        public int Power { get; private set; }

        /// <summary>
        /// Race is a characteristic of a creature.
        /// </summary>
        public ICollection<Race> Races { get; }

        public ICollection<TriggeredAbility> TriggerAbilities { get; }

        public bool SummoningSickness { get; }

        protected Creature(int cost, IEnumerable<Civilization> civilizations, int power, IEnumerable<Race> races) : base(cost, civilizations)
        {
            Power = power;
            Races = new Collection<Race>(races.ToList());
        }

        protected Creature(int cost, Civilization civilization, int power, Race races) : this(cost, new List<Civilization> {civilization}, power, new List<Race> {races}) {}
    }
}
