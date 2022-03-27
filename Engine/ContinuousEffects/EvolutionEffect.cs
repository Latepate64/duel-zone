namespace Engine.ContinuousEffects
{
    public abstract class EvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        protected EvolutionEffect(EvolutionEffect effect) : base(effect)
        {
        }

        protected EvolutionEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }

        public abstract bool CanEvolveFrom(ICard card);
    }
}
