using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect : PowerAttackerEffect
    {
        private readonly Subtype _subtype;

        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(Subtype subtype, int power) : base(new PowerAttackerEffect(power, new Conditions.HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition(subtype)))
        {
            _subtype = subtype;
        }

        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public override string ToString()
        {
            return $"While you have at least one {_subtype} in the battle zone, this creature gets +{_power} power during its attacks.";
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(this);
        }
    }
}