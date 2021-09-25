using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class SpeedAttacker : StaticAbility
    {
        internal SpeedAttacker(Creature creature) : base(creature)
        { }

        protected SpeedAttacker(SpeedAttacker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new SpeedAttacker(this);
        }
    }

    internal class DoubleBreaker : StaticAbility
    {
        internal DoubleBreaker(Creature creature) : base(creature) { }

        protected DoubleBreaker(DoubleBreaker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreaker(this);
        }
    }
}

