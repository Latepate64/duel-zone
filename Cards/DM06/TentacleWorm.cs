namespace Cards.DM06
{
    sealed class TentacleWorm : Creature
    {
        public TentacleWorm() : base("Tentacle Worm", 4, 3000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
        }
    }
}
