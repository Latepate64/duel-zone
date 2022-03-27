using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base(new ContinuousEffects.ThisCreatureHasBlockerEffect())
        {
        }
    }
}
