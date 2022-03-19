namespace Engine.ContinuousEffects
{
    public class AttacksIfAbleEffect : ContinuousEffect
    {
        public AttacksIfAbleEffect(ICardFilter filter) : base(filter)
        {
        }

        public AttacksIfAbleEffect(AttacksIfAbleEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AttacksIfAbleEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} attacks if able{GetDurationAsText()}.";
        }
    }
}
