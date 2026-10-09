using Abilities.Static;

namespace Cards.DM06
{
    sealed class CantankerousGiant : Creature
    {
        public CantankerousGiant() : base("Cantankerous Giant", 7, 8000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
