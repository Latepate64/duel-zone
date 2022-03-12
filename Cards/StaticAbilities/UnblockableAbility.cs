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

        public UnblockableAbility(params Condition[] conditions) : this(new BattleZoneCreatureFilter(), conditions)
        {
        }

        public UnblockableAbility(CardFilter blockerFilter, params Condition[] conditions) : base(new UnblockableEffect(new TargetFilter(), new Indefinite(), blockerFilter, conditions))
        {
        }
    }
}
