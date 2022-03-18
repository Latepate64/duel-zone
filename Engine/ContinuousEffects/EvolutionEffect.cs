using Common;

namespace Engine.ContinuousEffects
{
    public abstract class EvolutionEffect : ContinuousEffect
    {
        protected EvolutionEffect(EvolutionEffect effect) : base(effect)
        {
        }

        protected EvolutionEffect(CardFilter filter) : base(filter)
        {
        }

        public abstract bool CanEvolveFrom(Card card);
    }

    public class RaceEvolutionEffect : EvolutionEffect
    {
        public RaceEvolutionEffect(RaceEvolutionEffect effect) : base(effect)
        {
            Race = effect.Race;
        }

        public RaceEvolutionEffect(CardFilter filter, Subtype race) : base(filter)
        {
            Race = race;
        }

        public Subtype Race { get; }

        public override bool CanEvolveFrom(Card card)
        {
            return card.Subtypes.Contains(Race);
        }

        public override ContinuousEffect Copy()
        {
            return new RaceEvolutionEffect(this);
        }

        public override string ToString()
        {
            return $"Evolution - Put on one of your {Race}s.";
        }
    }
}
