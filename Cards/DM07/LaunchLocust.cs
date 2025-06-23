using ContinuousEffects;

namespace Cards.DM07
{
    sealed class LaunchLocust : Creature
    {
        public LaunchLocust() : base("Launch Locust", 3, 2000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new LeapingTornadoHornEffect());
        }
    }
}
