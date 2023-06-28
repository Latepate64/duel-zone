using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : UntilEndOfTurnEffect, IPowerModifyingEffect
    {
        private readonly int _power;
        private readonly ICard[] _cards;

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _power = effect._power;
            _cards = effect._cards;
        }

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power, params ICard[] cards) : base()
        {
            _power = power;
            _cards = cards;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public void ModifyPower()
        {
            _cards.ToList().ForEach(x => x.Power += _power);
        }

        public override string ToString()
        {
            return $"This creature has +{_power} power until the end of the turn.";
        }
    }
}
