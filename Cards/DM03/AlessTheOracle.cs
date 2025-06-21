using ContinuousEffects;

namespace Cards.DM03
{
    class AlessTheOracle : Engine.Creature
    {
        public AlessTheOracle() : base("Aless, the Oracle", 6, 1000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
