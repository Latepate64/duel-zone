using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public enum Race
    {
        ArmoredDragon,
        ArmoredWyvern,
        BeastFolk,
        CyberLord,
        Dragonoid,
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

        public ICollection<TriggeredAbility> TriggeredAbilities { get; private set; } = new Collection<TriggeredAbility>();

        /// <summary>
        /// Note: use AffectedBySummoningSickness to determine if creature is able to attack
        /// </summary>
        public bool SummoningSickness { get; private set; }

        protected Creature(Guid owner, int cost, IEnumerable<Civilization> civilizations, int power, IEnumerable<Race> races) : base(owner, cost, civilizations)
        {
            Power = power;
            Races = new Collection<Race>(races.ToList());
        }

        protected Creature(Guid owner, int cost, Civilization civilization, int power, Race races) : this(owner, cost, new List<Civilization> { civilization }, power, new List<Race> { races }) { }

        protected Creature(Creature creature) : base(creature)
        {
            Power = creature.Power;
            Races = new Collection<Race>(creature.Races.ToList());
            TriggeredAbilities = creature.TriggeredAbilities.Select(x => x.Copy()).Cast<TriggeredAbility>().ToList();
            SummoningSickness = creature.SummoningSickness;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal bool AffectedBySummoningSickness()
        {
            return SummoningSickness && !StaticAbilities.OfType<SpeedAttacker>().Any();
        }
    }

    internal class CreatureComparer : CardComparer, IEqualityComparer<Creature>
    {
        public bool Equals(Creature x, Creature y)
        {
            return base.Equals(x, y) &&
                x.Power == y.Power &&
                x.Races.SequenceEqual(y.Races) &&
                x.SummoningSickness == y.SummoningSickness &&
                x.TriggeredAbilities.Count == y.TriggeredAbilities.Count; //TODO: Actually compare abilitie
        }

        public int GetHashCode(Creature obj)
        {
            return base.GetHashCode(obj) + obj.Power + obj.SummoningSickness.GetHashCode(); //TODO: Races and TriggerAbilities
        }
    }
}
