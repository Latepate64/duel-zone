using Common;

namespace Cards.Cards.DM04
{
    class OuksVizierOfRestoration : Creature
    {
        public OuksVizierOfRestoration() : base("Ouks, Vizier of Restoration", 5, 1000, Subtype.Initiate, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadAbility());
        }
    }
}
