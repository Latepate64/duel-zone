namespace Engine.ContinuousEffects
{
    public class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public CardFilter TargetFilter { get; }

        public CanAttackUntappedCreaturesEffect(CanAttackUntappedCreaturesEffect effect) : base(effect)
        {
            TargetFilter = effect.TargetFilter.Copy();
        }

        public CanAttackUntappedCreaturesEffect(CardFilter targetFilter)
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
