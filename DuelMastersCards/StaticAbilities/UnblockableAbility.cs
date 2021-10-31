using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class UnblockableAbility : StaticAbility
    {
        public UnblockableAbility()
        {
            ContinuousEffects.Add(new UnblockableEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
