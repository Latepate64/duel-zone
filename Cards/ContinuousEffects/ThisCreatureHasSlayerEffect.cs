using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureHasSlayerEffect : SlayerEffect
    {
        public ThisCreatureHasSlayerEffect(SlayerEffect effect) : base(effect)
        {
        }

        public ThisCreatureHasSlayerEffect() : base(new Engine.TargetFilter(), new CardFilters.BattleZoneCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureHasSlayerEffect();
        }

        public override string ToString()
        {
            return "Slayer";
        }
    }
}