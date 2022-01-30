using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.StaticAbilities
{
    public class DoubleBreakerAbility : StaticAbility
    {
        public DoubleBreakerAbility() : base()
        {
            ContinuousEffects.Add(new DoubleBreakerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}