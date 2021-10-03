using DuelMastersModels.Abilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// 110.1. A permanent is a card or token on the battle zone. A permanent remains on the battle zone indefinitely. A card or token becomes a permanent as it enters the battlefield and it stops being a permanent as it’s moved to another zone by an effect or rule.
    /// </summary>
    public class Permanent : DuelObject, IAttackable
    {
        public Card Card { get; set; }

        /// <summary>
        /// Note: use AffectedBySummoningSickness to determine if creature is able to attack
        /// </summary>
        public bool SummoningSickness { get; internal set; } = true;

        /// <summary>
        /// 110.2. A permanent’s owner is the same as the owner of the card that represents it (unless it’s a token; see rule 111.2). A permanent’s controller is, by default, the player under whose control it entered the battle zone. Every permanent has a controller.
        /// </summary>
        public Guid Controller { get; set; }

        public Permanent(Card card) : base()
        {
            Card = card;
            Controller = card.Owner;

            foreach (var x in card.Abilities)
            {
                x.SourcePermanent = Id;
            }
        }

        public Permanent(Permanent permanent) : base(permanent)
        {
            Card = permanent.Card.Copy();
            Controller = permanent.Controller;
            SummoningSickness = permanent.SummoningSickness;
        }

        internal bool AffectedBySummoningSickness()
        {
            return SummoningSickness && !Card.Abilities.OfType<SpeedAttacker>().Any();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Card.Dispose();
                Card = null;
            }
        }
    }

    internal class PermanentComparer : IEqualityComparer<Permanent>
    {
        public bool Equals(Permanent x, Permanent y)
        {
            return new CardComparer().Equals(x.Card, y.Card) &&
                x.Controller == y.Controller &&
                x.SummoningSickness == y.SummoningSickness;
        }

        public int GetHashCode(Permanent obj)
        {
            return obj.Card.GetHashCode() + obj.SummoningSickness.GetHashCode();
        }
    }
}
