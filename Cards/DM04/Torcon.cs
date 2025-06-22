namespace Cards.DM04
{
    sealed class Torcon : Engine.Creature
    {
        public Torcon() : base("Torcon", 2, 1000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
        }
    }
}
