using Common;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility : StaticAbility
    {
        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility(Subtype subtype, int power) : base(new ContinuousEffects.WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(subtype, power))
        {
        }
    }
}
