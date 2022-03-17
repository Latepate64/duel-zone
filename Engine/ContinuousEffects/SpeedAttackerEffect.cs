namespace Engine.ContinuousEffects
{
    public class SpeedAttackerEffect : ContinuousEffect
    {
        public SpeedAttackerEffect(CardFilter filter) : base(filter)
        {
        }

        public SpeedAttackerEffect(SpeedAttackerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new SpeedAttackerEffect(this);
        }

        public override string ToString()
        {
            return "Speed attacker";
        }
    }
}
