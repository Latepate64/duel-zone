using ContinuousEffects;

namespace Cards.DM04
{
    class OuksVizierOfRestoration : Engine.Creature
    {
        public OuksVizierOfRestoration() : base("Ouks, Vizier of Restoration", 5, 1000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
