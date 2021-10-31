using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class UnblockableAbility : StaticAbility
    {
        public CardFilter BlockerFilter { get; }

        public UnblockableAbility() : this(new AnyFilter())
        {
        }

        public UnblockableAbility(CardFilter blockerFilter)
        {
            ContinuousEffects.Add(new UnblockableEffect(new TargetFilter(), new Indefinite(), blockerFilter));
        }
    }
}
