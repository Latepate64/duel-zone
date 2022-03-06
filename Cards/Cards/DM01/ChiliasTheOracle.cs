using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class ChiliasTheOracle : Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, 2500, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            // When this creature would be destroyed, put it into your hand instead.
            AddAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
