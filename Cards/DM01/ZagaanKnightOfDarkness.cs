using Abilities.Static;

namespace Cards.DM01
{
    sealed class ZagaanKnightOfDarkness : Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, 7000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
