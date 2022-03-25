using Common;

namespace Engine.ContinuousEffects
{
    public abstract class EvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        protected EvolutionEffect(EvolutionEffect effect) : base(effect)
        {
        }

        protected EvolutionEffect(ICardFilter filter) : base(filter)
        {
        }

        public abstract bool CanEvolveFrom(ICard card);
    }
}
