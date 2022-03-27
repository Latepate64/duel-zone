using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class OpponentCannotChooseThisCreatureAbility : StaticAbility
    {
        public OpponentCannotChooseThisCreatureAbility() : base(new OpponentCannotChooseThisCreatureEffect())
        {
        }
    }

    class OpponentCannotChooseThisCreatureEffect : UnchoosableEffect
    {
        public OpponentCannotChooseThisCreatureEffect() : base(new Engine.TargetFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new OpponentCannotChooseThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Whenever your opponent would choose a creature in the battle zone, he can't choose this one.";
        }
    }
}
