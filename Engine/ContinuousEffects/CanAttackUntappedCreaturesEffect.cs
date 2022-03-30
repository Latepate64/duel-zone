namespace Engine.ContinuousEffects
{
    public abstract class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public ICardFilter TargetFilter { get; }

        protected CanAttackUntappedCreaturesEffect(CanAttackUntappedCreaturesEffect effect) : base(effect)
        {
            TargetFilter = effect.TargetFilter.Copy();
        }

        protected CanAttackUntappedCreaturesEffect(ICardFilter targetFilter, IDuration duration, params Condition[] conditions) : this(new TargetFilter(), targetFilter, duration, conditions)
        {
        }

        protected CanAttackUntappedCreaturesEffect(ICardFilter attackerFilter, ICardFilter targetFilter, IDuration duration, params Condition[] conditions) : base(attackerFilter, duration, conditions)
        {
            TargetFilter = targetFilter;
        }

        internal bool Applies(ICard targetOfAttack, IGame game)
        {
            return TargetFilter.Applies(targetOfAttack, game, game.GetOwner(targetOfAttack));
        }
    }
}
