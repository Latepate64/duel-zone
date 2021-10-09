using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class CannotAttackCreaturesAbility : StaticAbility
    {
        public CannotAttackCreaturesAbility() : base()
        {
            ContinuousEffects.Add(new CannotAttackCreaturesEffect(new TargetFilter(), new Indefinite()));
        }

        public CannotAttackCreaturesAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new CannotAttackCreaturesAbility(this);
        }
    }
}
