using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class CanAttackUntappedCreaturesAbility : StaticAbility
    {
        public CanAttackUntappedCreaturesAbility()
        {
            ContinuousEffects.Add(new CanAttackUntappedCreaturesEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
