using Common;

namespace Cards.Cards.DM10
{
    class CrystalSpinslicer : EvolutionCreature
    {
        public CrystalSpinslicer() : base("Crystal Spinslicer", 2, 5000, Engine.Subtype.LiquidPeople, Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
