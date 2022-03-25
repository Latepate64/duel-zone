using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base(new ThisCreatureHasBlockerEffect())
        {
        }
    }

    public class ThisCreatureHasBlockerEffect : BlockerEffect
    {
        public ThisCreatureHasBlockerEffect() : base(new Engine.TargetFilter(), new CardFilters.OpponentsBattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureHasBlockerEffect();
        }

        public override string ToString()
        {
            return "Blocker";
        }
    }
}
