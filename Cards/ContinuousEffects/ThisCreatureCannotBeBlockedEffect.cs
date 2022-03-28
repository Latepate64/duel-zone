using Cards.CardFilters;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotBeBlockedEffect : UnblockableEffect
    {
        public ThisCreatureCannotBeBlockedEffect(ThisCreatureCannotBeBlockedEffect effect) : base(effect)
        {
        }

        public ThisCreatureCannotBeBlockedEffect() : base(new TargetFilter(), new Durations.Indefinite(), new BattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedEffect(this);
        }

        public override string ToString()
        {
            return "This creature can't be blocked.";
        }
    }
}