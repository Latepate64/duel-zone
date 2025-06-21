using ContinuousEffects;

namespace Cards.DM07
{
    class LaunchLocust : Engine.Creature
    {
        public LaunchLocust() : base("Launch Locust", 3, 2000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new LeapingTornadoHornEffect());
        }
    }
}
