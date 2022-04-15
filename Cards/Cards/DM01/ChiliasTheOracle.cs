using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class ChiliasTheOracle : Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, 2500, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
