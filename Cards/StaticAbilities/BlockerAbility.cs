using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base(new BlockerEffect())
        {
        }
    }
}
