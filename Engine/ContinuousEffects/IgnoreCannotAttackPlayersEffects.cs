using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class IgnoreCannotAttackPlayersEffects : ContinuousEffect
    {
        public IgnoreCannotAttackPlayersEffects(IgnoreCannotAttackPlayersEffects effect) : base(effect)
        {
        }

        public IgnoreCannotAttackPlayersEffects(CardFilter filter, Duration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new IgnoreCannotAttackPlayersEffects(this);
        }

        public override string ToString()
        {
            return $"Ignore any effects that would prevent {Filter} from attacking your opponent.";
        }
    }
}
