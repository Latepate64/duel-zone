using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class CannotAttackCreaturesAbility : StaticAbility
    {
        public CannotAttackCreaturesAbility() : base()
        {
            ContinuousEffects.Add(new CannotAttackCreaturesEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
