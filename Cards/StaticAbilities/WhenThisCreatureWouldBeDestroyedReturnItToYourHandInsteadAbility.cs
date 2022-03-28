using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility() : base(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect())
        {
        }
    }
}
