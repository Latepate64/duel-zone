namespace Engine.ContinuousEffects
{
    public abstract class SlayerEffect : ContinuousEffect
    {
        public ICardFilter WorksAgainstFilter { get; }

        protected SlayerEffect(ICardFilter filter, ICardFilter worksAgainstFilter) : base(filter)
        {
            WorksAgainstFilter = worksAgainstFilter;
        }

        protected SlayerEffect(SlayerEffect effect) : base(effect)
        {
            WorksAgainstFilter = effect.WorksAgainstFilter;
        }
    }
}
