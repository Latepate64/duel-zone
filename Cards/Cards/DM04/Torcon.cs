namespace Cards.Cards.DM04
{
    class Torcon : Creature
    {
        public Torcon() : base("Torcon", 2, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
        }
    }
}
