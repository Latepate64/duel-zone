using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class ZagaanKnightOfDarkness : Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, Common.Civilization.Darkness, 7000, Common.Subtype.DemonCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
