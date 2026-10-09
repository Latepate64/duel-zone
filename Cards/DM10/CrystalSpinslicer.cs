using Abilities.Static;

namespace Cards.DM10
{
    sealed class CrystalSpinslicer : EvolutionCreature
    {
        public CrystalSpinslicer() : base("Crystal Spinslicer", 2, 5000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
