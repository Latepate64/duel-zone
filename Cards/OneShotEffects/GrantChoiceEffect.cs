using Engine;

namespace Cards.OneShotEffects
{
    abstract class GrantChoiceEffect : CardSelectionEffect
    {
        public Duration Duration { get; }

        protected GrantChoiceEffect(GrantChoiceEffect effect) : base(effect)
        {
            Duration = effect.Duration;
        }

        protected GrantChoiceEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses)
        {
            Duration = new Durations.UntilTheEndOfTheTurn();
        }
    }
}
