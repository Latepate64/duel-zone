using DuelMastersModels.Abilities.Static;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// 110.1. A permanent is a card or token on the battle zone. A permanent remains on the battle zone indefinitely. A card or token becomes a permanent as it enters the battlefield and it stops being a permanent as it’s moved to another zone by an effect or rule.
    /// </summary>
    public class Permanent : Card, IAttackable
    {
        /// <summary>
        /// Note: use AffectedBySummoningSickness to determine if creature is able to attack
        /// </summary>
        public bool SummoningSickness { get; internal set; } = true;

        public Permanent(Card card) : base(card, false)
        {
            Controller = card.Owner;
            foreach (var x in card.Abilities)
            {
                x.Source = Id;
                x.Controller = card.Owner;
            }
        }

        public Permanent(Permanent permanent) : base(permanent, true)
        {
            Controller = permanent.Controller;
            SummoningSickness = permanent.SummoningSickness;
        }

        internal bool AffectedBySummoningSickness()
        {
            return SummoningSickness && !Abilities.OfType<SpeedAttacker>().Any();
        }
    }

    public class PermanentComparer : IEqualityComparer<Permanent>
    {
        public bool Equals(Permanent x, Permanent y)
        {
            return new CardComparer().Equals(x, y) &&
                x.Controller == y.Controller &&
                x.SummoningSickness == y.SummoningSickness;
        }

        public int GetHashCode(Permanent obj)
        {
            return obj.Controller.GetHashCode() + obj.SummoningSickness.GetHashCode(); //obj.Card.GetHashCode() + 
        }
    }
}
