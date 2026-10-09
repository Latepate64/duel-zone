using Abilities.Static;

namespace Cards.DM05
{
    sealed class LaGuileSeekerOfSkyfire : Creature
    {
        public LaGuileSeekerOfSkyfire() : base("La Guile, Seeker of Skyfire", 6, 7500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
