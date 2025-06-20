using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM03
{
    class RazaVegaThunderGuardian : Engine.Creature
    {
        public RazaVegaThunderGuardian() : base("Raza Vega, Thunder Guardian", 10, 3000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
