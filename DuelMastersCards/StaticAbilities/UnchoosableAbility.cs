using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class UnchoosableAbility : StaticAbility
    {
        public UnchoosableAbility()
        {
            ContinuousEffects.Add(new UnchoosableEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
