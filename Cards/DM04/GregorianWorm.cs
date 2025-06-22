namespace Cards.DM04
{
    sealed class GregorianWorm : Engine.Creature
    {
        public GregorianWorm() : base("Gregorian Worm", 4, 3000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
        }
    }
}
