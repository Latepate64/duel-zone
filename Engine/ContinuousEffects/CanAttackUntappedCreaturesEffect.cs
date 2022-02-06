namespace Engine.ContinuousEffects
{
    public class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public CanAttackUntappedCreaturesEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public CanAttackUntappedCreaturesEffect()
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CanAttackUntappedCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can attack untapped creatures{GetDurationAsText()}.";
        }
    }
}
