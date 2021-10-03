using DuelMastersModels.Abilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public enum CardType { Creature, Spell }

    public enum Subtype
    {
        ArmoredDragon,
        ArmoredWyvern,
        Armorloid,
        BeastFolk,
        CyberLord,
        Dragonoid,
        EarthDragon,
        GiantInsect,
        Human,
        LiquidPeople,
        MachineEater,
        SnowFaerie,
    }

    public enum Civilization { Light, Water, Darkness, Fire, Nature };

    public class Card : DuelObject, ICopyable<Card>
    {
        // 109.3. An object’s characteristics are name, mana cost, color, color indicator, card type, subtype, supertype, rules text, abilities, power, toughness, loyalty, hand modifier, and life modifier. Objects can have some or all of these characteristics. Any other information about an object isn’t a characteristic.

        public string Name { get; set; }

        public CardType CardType { get; set; }

        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public IEnumerable<Subtype> Subtypes { get; set; }

        public ICollection<Ability> Abilities { get; } = new Collection<Ability>();

        public int? Power { get; set; }

        public Guid Owner { get; set; }

        public IEnumerable<Civilization> Civilizations { get; set; }

        public int ManaCost { get; set; }

        internal bool Tapped { get; set; }

        public bool ShieldTrigger { get; set; } = false;

        internal bool ShieldTriggerPending { get; set; } = false;

        public IEnumerable<Guid> RevealedTo { get; internal set; } = new List<Guid>();

        public Card()
        {
        }

        protected Card(Card card) : base(card)
        {
            Abilities = card.Abilities.Select(x => x.Copy()).ToList();
            CardType = card.CardType;
            Civilizations = card.Civilizations.ToList();
            ManaCost = card.ManaCost;
            Name = card.Name;
            Owner = card.Owner;
            Power = card.Power;
            RevealedTo = card.RevealedTo.ToList();
            ShieldTrigger = card.ShieldTrigger;
            ShieldTriggerPending = card.ShieldTriggerPending;
            Subtypes = card.Subtypes?.ToList();
            Tapped = card.Tapped;
        }

        public virtual Card Copy()
        {
            return new Card(this);
        }

        public override string ToString()
        {
            return Name + " " + Id.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Civilizations = null;
                RevealedTo = null;
            }
        }

        public virtual void EnterManaZone()
        {
            if (Civilizations.Count() > 1)
            {
                Tapped = true;
            }
        }
    }

    internal class CardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return x.Civilizations.SequenceEqual(y.Civilizations) &&
                x.ManaCost == y.ManaCost &&
                x.ShieldTrigger == y.ShieldTrigger &&
                x.ShieldTriggerPending == y.ShieldTriggerPending &&
                x.Tapped == y.Tapped;
        }

        public int GetHashCode(Card obj)
        {
            var x = 0;//obj.Civilizations.GetHashCode();
            var y = 0;// obj.StaticAbilities.GetHashCode();
            return obj.ManaCost + obj.Tapped.GetHashCode() + obj.ShieldTrigger.GetHashCode() + obj.ShieldTriggerPending.GetHashCode() + x + y;// + obj.StaticAbilities.Sum(x => x.GetHashCode());
        }
    }

    internal class CardsComparer : IEqualityComparer<IEnumerable<Card>>
    {
        public bool Equals(IEnumerable<Card> x, IEnumerable<Card> y)
        {
            return x.SequenceEqual(y, new CardComparer());
        }

        public int GetHashCode(IEnumerable<Card> obj)
        {
            var cardComparer = new CardComparer();
            return obj.Sum(x => cardComparer.GetHashCode(x));
        }
    }
}
