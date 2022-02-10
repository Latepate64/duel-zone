using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class ChiliasTheOracle : Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, Common.Civilization.Light, 2500, Common.Subtype.LightBringer)
        {
            // When this creature would be destroyed, put it into your hand instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
