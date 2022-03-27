using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class LeapingTornadoHornAbility : StaticAbility
    {
        public LeapingTornadoHornAbility() : base(new ContinuousEffects.LeapingTornadoHornEffect())
        {
        }
    }
}
