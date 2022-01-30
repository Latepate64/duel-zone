using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class UnchoosableAbility : StaticAbility
    {
        public UnchoosableAbility()
        {
            ContinuousEffects.Add(new UnchoosableEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
