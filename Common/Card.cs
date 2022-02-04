using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Card
    {
        public Card()
        {
            Id = Guid.NewGuid();
        }

        public Card(Card card)
        {
            Id = card.Id;
            Owner = card.Owner;

            CardType = card.CardType;
            Civilizations = card.Civilizations.ToList();
            ManaCost = card.ManaCost;
            Name = card.Name;
            Power = card.Power;
            RevealedTo = card.RevealedTo.ToList();
            ShieldTrigger = card.ShieldTrigger;
            Subtypes = card.Subtypes?.ToList();
            SummoningSickness = card.SummoningSickness;
            Tapped = card.Tapped;
        }
        public override string ToString()
        {
            return Name;
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
        public List<Subtype> Subtypes { get; set; } = new List<Subtype>();

        public int? Power { get; set; }

        public List<Civilization> Civilizations { get; set; }

        public int ManaCost { get; set; }

        public bool Tapped { get; set; }

        public bool ShieldTrigger { get; set; } = false;

        public List<Guid> RevealedTo { get; set; } = new List<Guid>();

        public bool SummoningSickness { get; set; } = true;
    }
}
