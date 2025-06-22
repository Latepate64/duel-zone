using ContinuousEffects;

namespace Cards.DM03
{
    sealed class AlessTheOracle : Engine.Creature
    {
        public AlessTheOracle() : base("Aless, the Oracle", 6, 1000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
