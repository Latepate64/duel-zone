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

        public UnblockableAbility(CardFilter blockerFilter) : base(new UnblockableEffect(new TargetFilter(), new Indefinite(), blockerFilter))
        {
        }
    }

    public class ThisCreatureCannotBeBlockedAbility : StaticAbility
    {
        public ThisCreatureCannotBeBlockedAbility() : base(new ThisCreatureCannotBeEffect())
        {
        }
    }

    public class ThisCreatureCannotBeEffect : UnblockableEffect
    {
        public ThisCreatureCannotBeEffect(ThisCreatureCannotBeEffect effect) : base(effect)
        {
        }

        public ThisCreatureCannotBeEffect() : base(new TargetFilter(), new BattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeEffect(this);
        }

        public override string ToString()
        {
            return "This creature can't be blocked.";
        }
    }
}
