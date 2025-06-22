using ContinuousEffects;

namespace Cards.DM06
{
    sealed class RazorpineTree : Engine.Creature
    {
        public RazorpineTree() : base("Razorpine Tree", 5, 1000, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachShieldYouHaveEffect(2000));
        }
    }
}
