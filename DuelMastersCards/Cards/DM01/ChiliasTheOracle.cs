using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class ChiliasTheOracle : Creature
    {
        public ChiliasTheOracle() : base("Chilias, the Oracle", 4, Civilization.Light, 2500, Subtype.LightBringer)
        {
            // When this creature would be destroyed, put it into your hand instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
