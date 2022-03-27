namespace Engine.ContinuousEffects
{
    public abstract class SlayerEffect : ContinuousEffect
    {
        public ICardFilter WorksAgainstFilter { get; }

        protected SlayerEffect(ICardFilter filter, ICardFilter worksAgainstFilter, IDuration duration) : base(filter, duration)
        {
            WorksAgainstFilter = worksAgainstFilter;
        }

        protected SlayerEffect(SlayerEffect effect) : base(effect)
        {
            WorksAgainstFilter = effect.WorksAgainstFilter;
        }
    }
}
