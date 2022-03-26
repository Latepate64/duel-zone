using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class WhileYourOpponentHasNoShieldsThisCreatureCannotAttackAbility : Engine.Abilities.StaticAbility
    {
        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackAbility() : base(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect())
        {
        }
    }

    class WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect : CannotAttackEffect
    {
        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect() : base(new Engine.TargetFilter(), new Durations.Indefinite(), new Conditions.FilterNoneCondition(new CardFilters.OpponentsShieldZoneCardFilter())) { }

        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect(WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect(this);
        }

        public override string ToString()
        {
            return "While your opponent has no shields, this creature can't attack.";
        }
    }
}