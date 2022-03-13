using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class TripleBreakerAbility : StaticAbility
    {
        public TripleBreakerAbility() : base(new TripleBreakerEffect())
        {
        }
    }
}