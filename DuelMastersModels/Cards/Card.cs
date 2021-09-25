﻿using DuelMastersModels.Abilities.StaticAbilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public abstract class Card : DuelObject, ICopyable<Card>
    {
        public IEnumerable<Civilization> Civilizations { get; private set; }

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        public int Cost { get; private set; }

        public bool Tapped { get; set; }

        public IList<StaticAbility> StaticAbilities { get; private set; } = new List<StaticAbility>();

        public bool ShieldTrigger { get; protected set; } = false;

        public bool ShieldTriggerPending { get; internal set; } = false;

        protected Card(int cost, IEnumerable<Civilization> civilizations)
        {
            Civilizations = civilizations;
            Cost = cost;
        }

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(int cost, Civilization civilization) : this(cost, new Collection<Civilization> { civilization }) { }

        protected Card(Card card) : base(card)
        {
            Civilizations = new Collection<Civilization>(card.Civilizations.ToList());
            Cost = card.Cost;
            ShieldTrigger = card.ShieldTrigger;
            ShieldTriggerPending = card.ShieldTriggerPending;
            StaticAbilities = card.StaticAbilities.Select(x => x.Copy()).Cast<StaticAbility>().ToList();
            Tapped = card.Tapped;
        }

        public abstract Card Copy();

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    internal class CardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return x.Civilizations.SequenceEqual(y.Civilizations) &&
                x.Cost == y.Cost &&
                x.ShieldTrigger == y.ShieldTrigger &&
                x.ShieldTriggerPending == y.ShieldTriggerPending &&
                x.StaticAbilities.Count == y.StaticAbilities.Count &&   //TODO: Actually compare abilities
                x.Tapped == y.Tapped;
        }

        public int GetHashCode(Card obj)
        {
            var x = 0;//obj.Civilizations.GetHashCode();
            var y = 0;// obj.StaticAbilities.GetHashCode();
            return obj.Cost + obj.Tapped.GetHashCode() + obj.ShieldTrigger.GetHashCode() + obj.ShieldTriggerPending.GetHashCode() + x + y;// + obj.StaticAbilities.Sum(x => x.GetHashCode());
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
