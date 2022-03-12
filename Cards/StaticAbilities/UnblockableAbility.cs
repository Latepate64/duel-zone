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

        public UnblockableAbility() : this(new BattleZoneCreatureFilter())
        {
        }

        public UnblockableAbility(CardFilter blockerFilter) : base(new UnblockableEffect(new TargetFilter(), new Indefinite(), blockerFilter))
        {
        }
    }
}
