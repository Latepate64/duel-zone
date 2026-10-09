using Abilities.Static;

namespace Cards.DM05
{
    sealed class BillionDegreeDragon : Creature
    {
        public BillionDegreeDragon() : base("Billion-Degree Dragon", 10, 15000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddAbilities(new TripleBreakerAbility());
        }
    }
}
