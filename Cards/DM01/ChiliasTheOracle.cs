using ContinuousEffects;

namespace Cards.DM01
{
    sealed class ChiliasTheOracle : Engine.Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, 2500, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
