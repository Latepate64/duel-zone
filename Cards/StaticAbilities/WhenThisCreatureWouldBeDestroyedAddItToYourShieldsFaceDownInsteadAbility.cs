using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadAbility() : base(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect())
        {
        }
    }
}
