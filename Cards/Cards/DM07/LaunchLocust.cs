using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class LaunchLocust : Creature
    {
        public LaunchLocust() : base("Launch Locust", 3, 2000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new LeapingTornadoHornEffect());
        }
    }
}
