using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class RazorpineTree : Engine.Creature
    {
        public RazorpineTree() : base("Razorpine Tree", 5, 1000, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachShieldYouHaveEffect(2000));
        }
    }
}
