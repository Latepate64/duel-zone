using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class ZagaanKnightOfDarkness : Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, Civilization.Darkness, 7000, Subtype.DemonCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
