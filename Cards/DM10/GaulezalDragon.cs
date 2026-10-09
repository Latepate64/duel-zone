using Abilities.Static;

namespace Cards.DM10
{
    sealed class GaulezalDragon : Creature
    {
        public GaulezalDragon() : base("Gaulezal Dragon", 9, 11000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
