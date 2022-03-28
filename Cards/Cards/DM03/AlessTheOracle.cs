using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class AlessTheOracle : Creature
    {
        public AlessTheOracle() : base("Aless, the Oracle", 6, 1000, Subtype.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
