using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class DoubleBreakerAbility : StaticAbility
    {
        public DoubleBreakerAbility() : base()
        {
            ContinuousEffects.Add(new DoubleBreakerEffect());
        }
    }
}