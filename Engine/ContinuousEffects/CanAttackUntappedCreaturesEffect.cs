namespace Engine.ContinuousEffects
{
    public abstract class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public ICardFilter TargetFilter { get; }

        protected CanAttackUntappedCreaturesEffect(CanAttackUntappedCreaturesEffect effect) : base(effect)
        {
            TargetFilter = effect.TargetFilter.Copy();
        }

        protected CanAttackUntappedCreaturesEffect(ICardFilter targetFilter, IDuration duration) : this(new TargetFilter(), targetFilter, duration)
        {
        }

        protected CanAttackUntappedCreaturesEffect(ICardFilter attackerFilter, ICardFilter targetFilter, IDuration duration) : base(attackerFilter, duration)
        {
            TargetFilter = targetFilter;
        }
    }
}
