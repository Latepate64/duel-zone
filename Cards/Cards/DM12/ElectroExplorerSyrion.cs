using Common;

namespace Cards.Cards.DM12
{
    class ElectroExplorerSyrion : Creature
    {
        public ElectroExplorerSyrion() : base("Electro Explorer Syrion", 3, 4000, Civilization.Light, Civilization.Water)
        {
            AddSubtypes(Subtype.Gladiator, Subtype.CyberLord);
        }
    }
}
