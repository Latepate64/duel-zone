namespace Engine.ContinuousEffects
{
    public class CannotAttackCreaturesEffect : ContinuousEffect
    {
        public CannotAttackCreaturesEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }

        public CannotAttackCreaturesEffect(CannotAttackCreaturesEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CannotAttackCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can't attack creatures{GetDurationAsText()}.";
        }
    }
}
