using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : PowerModifyingEffect
    {
        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power, params ICard[] cards) : base(power, new CardFilters.TargetsFilter(cards.ToArray()), new Durations.UntilTheEndOfTheTurn())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"This creature has +{_power} power until the end of the turn.";
        }
    }
}
