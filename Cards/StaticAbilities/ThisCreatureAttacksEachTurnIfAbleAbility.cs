using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class ThisCreatureAttacksEachTurnIfAbleAbility : StaticAbility
    {
        public ThisCreatureAttacksEachTurnIfAbleAbility() : base(new ThisCreatureAttacksEachTurnIfAbleEffect())
        {
        }
    }

    class ThisCreatureAttacksEachTurnIfAbleEffect : AttacksIfAbleEffect
    {
        public ThisCreatureAttacksEachTurnIfAbleEffect() : base(new Engine.TargetFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureAttacksEachTurnIfAbleEffect();
        }

        public override string ToString()
        {
            return "This creature attacks each turn if able.";
        }
    }
}
