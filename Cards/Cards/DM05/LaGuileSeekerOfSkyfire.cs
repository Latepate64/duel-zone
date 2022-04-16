namespace Cards.Cards.DM05
{
    class LaGuileSeekerOfSkyfire : Creature
    {
        public LaGuileSeekerOfSkyfire() : base("La Guile, Seeker of Skyfire", 6, 7500, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddDoubleBreakerAbility();
        }
    }
}
