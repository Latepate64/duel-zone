using Common;

namespace Cards.Cards.DM06
{
    class RazorpineTree : Creature
    {
        public RazorpineTree() : base("Razorpine Tree", 5, 1000, Subtype.StarlightTree, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.ThisCreatureGetsPowerForEachShieldYouHaveAbility(2000));
        }
    }
}
