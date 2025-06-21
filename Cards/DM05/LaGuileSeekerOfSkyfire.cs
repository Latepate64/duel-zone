using ContinuousEffects;

namespace Cards.DM05
{
    class LaGuileSeekerOfSkyfire : Engine.Creature
    {
        public LaGuileSeekerOfSkyfire() : base("La Guile, Seeker of Skyfire", 6, 7500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
