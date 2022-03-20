namespace Engine.ContinuousEffects
{
    public class CannotAttackEffect : GameRulesEffect
    {
        public CannotAttackEffect(CannotAttackEffect effect) : base(effect)
        {
        }

        public CannotAttackEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new CannotAttackEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can't attack";
        }
    }
}
