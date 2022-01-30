using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class SlayerAbility : StaticAbility
    {
        public SlayerAbility()
        {
            ContinuousEffects.Add(new SlayerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
