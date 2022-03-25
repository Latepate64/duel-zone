using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCanAttackUntappedCreaturesAbility : StaticAbility
    {
        public ThisCreatureCanAttackUntappedCreaturesAbility() : base(new ThisCreatureCanAttackUntappedCreaturesEffect())
        {
        }
    }

    class ThisCreatureCanAttackUntappedCreaturesEffect : CanAttackUntappedCreaturesEffect
    {
        public ThisCreatureCanAttackUntappedCreaturesEffect(ThisCreatureCanAttackUntappedCreaturesEffect effect) : base(effect)
        {
        }

        public ThisCreatureCanAttackUntappedCreaturesEffect() : base(new CardFilters.OpponentsBattleZoneUntappedCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCanAttackUntappedCreaturesEffect(this);
        }

        public override string ToString()
        {
            return "This creature can attack untapped creatures.";
        }
    }
}
