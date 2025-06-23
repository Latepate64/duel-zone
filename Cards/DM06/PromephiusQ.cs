namespace Cards.DM06
{
    sealed class PromephiusQ : Creature
    {
        public PromephiusQ() : base("Promephius Q", 3, 2000, [Interfaces.Race.Survivor, Interfaces.Race.SeaHacker], Interfaces.Civilization.Water)
        {
        }
    }
}
