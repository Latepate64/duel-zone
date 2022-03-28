using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class ChiliasTheOracle : Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, 2500, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
