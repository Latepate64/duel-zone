using ContinuousEffects;

namespace Cards.DM04
{
    sealed class OuksVizierOfRestoration : Creature
    {
        public OuksVizierOfRestoration() : base("Ouks, Vizier of Restoration", 5, 1000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect());
        }
    }
}
