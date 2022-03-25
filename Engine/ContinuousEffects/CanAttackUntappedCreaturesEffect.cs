namespace Engine.ContinuousEffects
{
    public abstract class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public ICardFilter TargetFilter { get; }

        protected CanAttackUntappedCreaturesEffect(CanAttackUntappedCreaturesEffect effect) : base(effect)
        {
            TargetFilter = effect.TargetFilter.Copy();
        }

        protected CanAttackUntappedCreaturesEffect(ICardFilter targetFilter) : this(new TargetFilter(), targetFilter)
        {
        }

        protected CanAttackUntappedCreaturesEffect(ICardFilter attackerFilter, ICardFilter targetFilter) : base(attackerFilter)
        {
            TargetFilter = targetFilter;
        }
    }
}
