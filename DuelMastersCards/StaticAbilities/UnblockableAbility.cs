using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
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
