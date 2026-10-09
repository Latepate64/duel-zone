using Abilities.Static;
using ContinuousEffects.Replacement;

namespace Cards.DM03
{
    sealed class RazaVegaThunderGuardian : Creature
    {
        public RazaVegaThunderGuardian() : base("Raza Vega, Thunder Guardian", 10, 3000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
