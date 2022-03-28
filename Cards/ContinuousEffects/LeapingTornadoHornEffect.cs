using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class LeapingTornadoHornEffect : PowerAttackerMultiplierEffect
    {
        public LeapingTornadoHornEffect() : base(1000, new CardFilters.OwnersOtherBattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LeapingTornadoHornEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each other creature you have in the battle zone.";
        }
    }
}