namespace Engine.ContinuousEffects
{
    public class SlayerEffect : ContinuousEffect
    {
        public ICardFilter WorksAgainstFilter { get; }

        public SlayerEffect(ICardFilter filter, ICardFilter worksAgainstFilter) : base(filter)
        {
            WorksAgainstFilter = worksAgainstFilter;
        }

        public SlayerEffect(SlayerEffect effect) : base(effect)
        {
            WorksAgainstFilter = effect.WorksAgainstFilter;
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
