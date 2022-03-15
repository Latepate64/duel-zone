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

        public PowerFilter Power { get; set; }

        public List<Subtype> Subtypes { get; } = new List<Subtype>();

        protected CardFilter() { }

        protected CardFilter(CardFilter filter)
        {
            Power = filter.Power;
            Subtypes = filter.Subtypes;
            Target = filter.Target;
        }

        protected CardFilter(Subtype subtype)
        {
            Subtypes.Add(subtype);
        }

        public virtual bool Applies(Card card, Game game, Player player) //TODO: Filter based on civilizations does not work
        {
            return player != null &&
                card != null &&
                (Power == null || Power.Applies(card)) &&
                (!Subtypes.Any() || card.Subtypes.Intersect(Subtypes).Any());
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
            var textPieces = new List<string>();
            if (Subtypes.Any())
            {
                textPieces.Add(string.Join(" ", string.Join("/", Subtypes)));
            }
            if (Power != null)
            {
                textPieces.Add(Power.ToString());
            }
            return string.Join(" ", textPieces);
        }

        public abstract override string ToString();
    }
}