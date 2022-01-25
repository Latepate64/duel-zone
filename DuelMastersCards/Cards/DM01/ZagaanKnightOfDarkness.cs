using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class ZagaanKnightOfDarkness : Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, Civilization.Darkness, 7000, Subtype.DemonCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
