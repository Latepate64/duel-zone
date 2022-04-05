using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly int _power;

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power, params ICard[] cards) : base(new CardFilters.TargetsFilter(cards.ToArray()), new Durations.UntilTheEndOfTheTurn())
        {
            _power = power;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += _power);
        }

        public override string ToString()
        {
            return $"This creature has +{_power} power until the end of the turn.";
        }
    }
}
