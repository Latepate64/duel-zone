using Abilities.Static;

namespace Cards.DM03
{
    sealed class BoltailDragon : Creature
    {
        public BoltailDragon() : base("Boltail Dragon", 7, 9000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
