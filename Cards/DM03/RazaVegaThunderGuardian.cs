using ContinuousEffects;

namespace Cards.DM03
{
    class RazaVegaThunderGuardian : Engine.Creature
    {
        public RazaVegaThunderGuardian() : base("Raza Vega, Thunder Guardian", 10, 3000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
