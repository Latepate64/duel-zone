using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public abstract class CardFilter : IDisposable
    {
        /// <summary>
        /// Target and/or source of the filter. Not all filters need to consider this in applying the filter. (eg. for creature with Speed Attacker ability this is the creature, for Super Sonic Jetpack selection this is the target of the effect)
        /// </summary>
        public Guid Target { get; set; }

        public List<Civilization> Civilizations { get; } = new List<Civilization>();

        public CardType CardType { get; set; } = CardType.Any;

        public string CardName { get; set; }

        protected CardFilter(CardFilter filter)
        {
            Target = filter.Target;
            Civilizations = filter.Civilizations;
            CardType = filter.CardType;
            CardName = filter.CardName;
        }

        protected CardFilter(params Civilization[] civilizations)
        {
            Civilizations.AddRange(civilizations);
        }

        public virtual bool Applies(Card card, Game game, Player player)
        {
            return card != null && (!Civilizations.Any() || card.Civilizations.Intersect(Civilizations).Any()) && (CardType == CardType.Any || card.CardType == CardType) && (string.IsNullOrEmpty(CardName) || card.Name == CardName);
        }

        public abstract CardFilter Copy();

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected string ToStringBase()
        {
            if (Civilizations.Any())
            {
                return string.Join(" ", string.Join("/", Civilizations), ToString(CardType));
            }
            else if (!string.IsNullOrEmpty(CardName))
            {
                return CardName;
            }
            else
            {
                return ToString(CardType);
            }
        }

        public abstract override string ToString();

        private static string ToString(CardType type)
        {
            return type switch
            {
                CardType.Creature => "creature",
                CardType.Spell => "spell",
                CardType.Any => "card",
                _ => throw new NotImplementedException(),
            };
        }
    }
}