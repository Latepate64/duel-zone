using Common;

namespace Cards.Cards.DM05
{
    class LaGuileSeekerOfSkyfire : Creature
    {
        public LaGuileSeekerOfSkyfire() : base("La Guile, Seeker of Skyfire", 6, 7500, Subtype.MechaThunder, Civilization.Light)
        {
            AddDoubleBreakerAbility();
        }
    }
}
