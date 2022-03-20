using Cards.ContinuousEffects;
using Common;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility : StaticAbility
    {
        private readonly Subtype _subtype;
        private readonly int _power;

        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility(Subtype subtype, int power) : base(new PowerAttackerEffect(power, new Conditions.HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition(subtype)))
        {
            _subtype = subtype;
            _power = power;
        }

        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility(WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility ability) : base(ability)
        {
            _subtype = ability._subtype;
            _power = ability._power;
        }

        public override string ToString()
        {
            return $"While you have at least one {_subtype} in the battle zone, this creature gets +{_power} power during its attacks.";
        }

        public override Ability Copy()
        {
            return new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility(this);
        }
    }
}
