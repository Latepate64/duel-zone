using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureHasBlockerEffect : BlockerEffect
    {
        public ThisCreatureHasBlockerEffect() : base(new Engine.TargetFilter(), new CardFilters.OpponentsBattleZoneCreatureFilter(), new Durations.Indefinite())
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
