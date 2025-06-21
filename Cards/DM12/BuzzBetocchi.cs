namespace Cards.DM12
{
    class BuzzBetocchi : Engine.Creature
    {
        public BuzzBetocchi() : base("Buzz Betocchi", 3, 4000, [Interfaces.Race.FireBird, Interfaces.Race.GiantInsect], Interfaces.Civilization.Fire, Interfaces.Civilization.Nature)
        {
        }
    }
}
