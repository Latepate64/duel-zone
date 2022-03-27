using Engine;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeAttackedAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeAttackedAbility() : base(new ThisCreatureCannotBeAttackedEffect())
        {
        }
    }

    class ThisCreatureCannotBeAttackedEffect : CannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedEffect() : base(new TargetFilter(), new CardFilters.BattleZoneCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedEffect();
        }

        public override string ToString()
        {
            return "This creature can't be attacked.";
        }
    }
}