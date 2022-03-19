namespace Engine.ContinuousEffects
{
    public class SlayerEffect : ContinuousEffect
    {
        public SlayerEffect(ICardFilter filter) : base(filter)
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
