using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class TripleBreakerAbility : StaticAbility
    {
        public TripleBreakerAbility() : base(new TripleBreakerEffect())
        {
        }
    }
}
