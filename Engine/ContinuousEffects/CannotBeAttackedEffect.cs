namespace Engine.ContinuousEffects
{
    public class CannotBeAttackedEffect : ContinuousEffect
    {
        public ICardFilter AttackerFilter { get; }

        public CannotBeAttackedEffect(CannotBeAttackedEffect effect) : base(effect)
        {
            AttackerFilter = effect.AttackerFilter.Copy();
        }

        public CannotBeAttackedEffect(ICardFilter filter, ICardFilter attackerFilter, params Condition[] conditions) : base(filter, conditions)
        {
            AttackerFilter = attackerFilter;
        }

        public override IContinuousEffect Copy()
        {
            return new CannotBeAttackedEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} cannot be attacked.";
        }
    }
}
