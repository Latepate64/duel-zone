using DuelMastersModels.Abilities.TriggeredAbilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public enum Race
    {
        ArmoredDragon,
        BeastFolk,
        EarthDragon,
        Human,
        LiquidPeople,
    }

    /// <summary>
    /// Creature is a card type.
    /// </summary>
    public abstract class Creature : Card, IAttackable
    {
        /// <summary>
        /// The base power of creature. Use Duel's method GetPower(creature) in order to get the actual power of a creature.
        /// </summary>
        public int Power { get; private set; }

        /// <summary>
        /// Race is a characteristic of a creature.
        /// </summary>
        public ICollection<Race> Races { get; private set; }

        public ICollection<TriggeredAbility> TriggerAbilities { get; private set; }

        public bool SummoningSickness { get; private set; }

        protected Creature(int cost, IEnumerable<Civilization> civilizations, int power, IEnumerable<Race> races) : base(cost, civilizations)
        {
            Power = power;
            Races = new Collection<Race>(races.ToList());
        }

        protected Creature(int cost, Civilization civilization, int power, Race races) : this(cost, new List<Civilization> { civilization }, power, new List<Race> { races }) { }

        protected Creature Copy(Creature creature)
        {
            creature = base.Copy(creature) as Creature;
            creature.Power = Power;
            creature.Races = new Collection<Race>(Races.ToList());
            creature.TriggerAbilities = TriggerAbilities.Select(x => x.Copy()).Cast<TriggeredAbility>().ToList();
            creature.SummoningSickness = SummoningSickness;
            return creature;
        }

        IAttackable ICopyable<IAttackable>.Copy()
        {
            return Copy() as IAttackable;
        }
    }
}
