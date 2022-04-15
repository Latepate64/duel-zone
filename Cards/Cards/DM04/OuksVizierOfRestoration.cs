using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class OuksVizierOfRestoration : Creature
    {
        public OuksVizierOfRestoration() : base("Ouks, Vizier of Restoration", 5, 1000, Engine.Subtype.Initiate, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
