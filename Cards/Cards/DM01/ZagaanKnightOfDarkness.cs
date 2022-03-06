using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class ZagaanKnightOfDarkness : Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, 7000, Common.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
