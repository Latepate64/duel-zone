using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class DoubleBreakerAbility : StaticAbility
    {
        public DoubleBreakerAbility(params Engine.Condition[] conditions) : base(new DoubleBreakerEffect(conditions))
        {
        }
    }
}