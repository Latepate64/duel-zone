using ContinuousEffects;

namespace Cards.DM04
{
    class OuksVizierOfRestoration : Engine.Creature
    {
        public OuksVizierOfRestoration() : base("Ouks, Vizier of Restoration", 5, 1000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
