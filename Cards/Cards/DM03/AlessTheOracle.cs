using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class AlessTheOracle : Creature
    {
        public AlessTheOracle() : base("Aless, the Oracle", 6, 1000, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
