using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class RazaVegaThunderGuardian : Creature
    {
        public RazaVegaThunderGuardian() : base("Raza Vega, Thunder Guardian", 10, 3000, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadAbility());
        }
    }
}
