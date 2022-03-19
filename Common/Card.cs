using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public enum Supertype
    {
        Evolution
    }

    public class Card : ICard
    {
        public Card()
        {
            Id = Guid.NewGuid();
        }

        public Card(Card card, bool clear)
        {
            Id = card.Id;
            Owner = card.Owner;
            KnownTo = card.KnownTo.ToList();
            if (!clear)
            {
                CardType = card.CardType;
                Civilizations = card.Civilizations.ToList();
                ManaCost = card.ManaCost;
                Name = card.Name;
                OnTopOf = card.OnTopOf;
                Power = card.Power;
                RulesText = card.RulesText;
                ShieldTrigger = card.ShieldTrigger;
                Subtypes = card.Subtypes?.ToList();
                SummoningSickness = card.SummoningSickness;
                Supertypes = card.Supertypes?.ToList();
                Tapped = card.Tapped;
                Underneath = card.Underneath;
            }
        }

        public override string ToString()
        {
            return Name ?? "a card";
        }

        public Guid Id { get; set; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Guid Owner { get; set; }

        public string Name { get; set; }

        public CardType CardType { get; set; }

        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public List<Subtype> Subtypes { get; set; } = new();

        public int? Power { get; set; }

        public List<Civilization> Civilizations { get; set; } = new();

        public int ManaCost { get; set; }

        public bool Tapped { get; set; }

        public bool ShieldTrigger { get; set; }

        public List<Guid> KnownTo { get; set; } = new();

        public bool SummoningSickness { get; set; }

        public string RulesText { get; set; }

        public List<Supertype> Supertypes { get; set; } = new();

        /// <summary>
        /// Id of the card this card is on top of.
        /// </summary>
        public Guid OnTopOf { get; set; }

        /// <summary>
        /// Id of the card this card is underneath of.
        /// </summary>
        public Guid Underneath { get; set; }
    }
}
