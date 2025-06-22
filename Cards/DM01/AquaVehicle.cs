namespace Cards.DM01
{
    sealed class AquaVehicle : Engine.Creature
    {
        public AquaVehicle() : base("Aqua Vehicle", 2, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
        }
    }
}
