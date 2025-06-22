namespace Cards.DM03
{
    sealed class HangWormFetidLarva : Engine.Creature
    {
        public HangWormFetidLarva() : base("Hang Worm, Fetid Larva", 5, 4000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
        }
    }
}
