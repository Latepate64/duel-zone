namespace Cards.Cards.DM04
{
    class AquaJolter : Engine.Creature
    {
        public AquaJolter() : base("Aqua Jolter", 3, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
