using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class RazorpineTree : Creature
    {
        public RazorpineTree() : base("Razorpine Tree", 5, 1000, Subtype.StarlightTree, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachShieldYouHaveEffect(2000));
        }
    }
}
