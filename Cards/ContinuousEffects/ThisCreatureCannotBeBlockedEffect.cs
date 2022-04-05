using Cards.CardFilters;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
    {
        public ThisCreatureCannotBeBlockedEffect(ThisCreatureCannotBeBlockedEffect effect) : base(effect)
        {
        }

        public ThisCreatureCannotBeBlockedEffect() : base(new TargetFilter())
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

        public bool Applies(ICard blocker, IGame game)
        {
            return true;
        }
    }
}