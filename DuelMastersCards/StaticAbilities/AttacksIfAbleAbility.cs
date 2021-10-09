using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class AttacksIfAbleAbility : StaticAbility
    {
        public AttacksIfAbleAbility() : base()
        {
            ContinuousEffects.Add(new AttacksIfAbleEffect(new TargetFilter(), new Indefinite()));
        }

        public AttacksIfAbleAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AttacksIfAbleAbility(this);
        }
    }
}
