using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility()
        {
            ContinuousEffects.Add(new ChargerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
