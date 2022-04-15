using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class RazaVegaThunderGuardian : Creature
    {
        public RazaVegaThunderGuardian() : base("Raza Vega, Thunder Guardian", 10, 3000, Engine.Subtype.Guardian, Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
