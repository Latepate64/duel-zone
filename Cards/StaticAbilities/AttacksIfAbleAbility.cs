using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class AttacksIfAbleAbility : StaticAbility
    {
        public AttacksIfAbleAbility() : base()
        {
            ContinuousEffects.Add(new AttacksIfAbleEffect());
        }
    }
}
