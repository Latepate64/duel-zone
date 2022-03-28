using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility() : base(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect())
        {
        }
    }
}
