namespace Cards.DM04
{
    sealed class AquaJolter : Engine.Creature
    {
        public AquaJolter() : base("Aqua Jolter", 3, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
