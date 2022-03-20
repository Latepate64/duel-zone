using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class UnchoosableAbility : StaticAbility
    {
        public UnchoosableAbility() : base(new UnchoosableEffect(new Engine.TargetFilter()))
        {
        }

        public override string ToString()
        {
            return "Whenever your opponent would choose a creature in the battle zone, he can't choose this one. (It can still be attacked and blocked.)";
        }
    }
}
