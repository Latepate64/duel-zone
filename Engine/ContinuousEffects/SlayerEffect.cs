namespace Engine.ContinuousEffects
{
    public class SlayerEffect : ContinuousEffect
    {
        public SlayerEffect()
        {

        }

        public SlayerEffect(SlayerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new SlayerEffect(this);
        }

        public override string ToString()
        {
            return "Slayer";
        }
    }
}
