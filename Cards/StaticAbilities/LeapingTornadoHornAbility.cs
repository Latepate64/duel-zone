using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class LeapingTornadoHornAbility : StaticAbility
    {
        public LeapingTornadoHornAbility() : base(new LeapingTornadoHornEffect())
        {
        }
    }

    class LeapingTornadoHornEffect : ContinuousEffects.PowerAttackerMultiplierEffect
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
