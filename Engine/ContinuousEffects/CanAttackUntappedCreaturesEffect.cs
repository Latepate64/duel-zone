namespace Engine.ContinuousEffects
{
    public class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public ICardFilter TargetFilter { get; }

        public CanAttackUntappedCreaturesEffect(CanAttackUntappedCreaturesEffect effect) : base(effect)
        {
            TargetFilter = effect.TargetFilter.Copy();
        }

        public CanAttackUntappedCreaturesEffect(ICardFilter targetFilter) : this(new TargetFilter(), targetFilter)
        {
        }

        public CanAttackUntappedCreaturesEffect(ICardFilter attackerFilter, ICardFilter targetFilter) : base(attackerFilter)
        {
            TargetFilter = targetFilter;
        }

        public override ContinuousEffect Copy()
        {
            return new CanAttackUntappedCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can attack {TargetFilter}{GetDurationAsText()}.";
        }
    }
}
