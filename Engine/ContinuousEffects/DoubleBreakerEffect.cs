namespace Engine.ContinuousEffects
{
    public class DoubleBreakerEffect : ContinuousEffect
    {
        public DoubleBreakerEffect()
        {
        }

        public DoubleBreakerEffect(DoubleBreakerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new DoubleBreakerEffect(this);
        }

        public override string ToString()
        {
            return "Double breaker (This creature breaks 2 shields.)";
        }
    }
}
