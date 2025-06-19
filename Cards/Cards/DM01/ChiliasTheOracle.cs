using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class ChiliasTheOracle : Engine.Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, 2500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
