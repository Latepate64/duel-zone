namespace Cards.DM12
{
    sealed class ElectroExplorerSyrion : Creature
    {
        public ElectroExplorerSyrion() : base("Electro Explorer Syrion", 3, 4000, [Interfaces.Race.Gladiator, Interfaces.Race.CyberLord], Interfaces.Civilization.Light, Interfaces.Civilization.Water)
        {
        }
    }
}
