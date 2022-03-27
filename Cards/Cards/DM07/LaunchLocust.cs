using Common;

namespace Cards.Cards.DM07
{
    class LaunchLocust : Creature
    {
        public LaunchLocust() : base("Launch Locust", 3, 2000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.LeapingTornadoHornAbility());
        }
    }
}
