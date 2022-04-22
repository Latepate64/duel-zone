using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ThisCreatureBreaksOpponentsShieldsEffect : BreaksOpponentsShieldsEffect
    {
        public ThisCreatureBreaksOpponentsShieldsEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
        {
        }

        public ThisCreatureBreaksOpponentsShieldsEffect(int amount = 1) : base(amount)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureBreaksOpponentsShieldsEffect(this);
        }

        public override string ToString()
        {
            return $"This creature breaks {_amount} of your opponent's shields.";
        }

        protected override ICard GetBreaker(IGame game, IAbility source)
        {
            return game.GetCard(Ability.Source);
        }
    }

    abstract class BreaksOpponentsShieldsEffect : OneShotEffect
    {
        protected readonly int _amount;

        protected BreaksOpponentsShieldsEffect(BreaksOpponentsShieldsEffect effect)
        {
            _amount = effect._amount;
        }

        protected BreaksOpponentsShieldsEffect(int amount = 1)
        {
            _amount = amount;
        }

        public override void Apply(IGame game)
        {
            GetBreaker(game, Ability).Break(game, _amount);
        }

        protected abstract ICard GetBreaker(IGame game, IAbility source);
    }

    class TargetCreatureBreaksOpponentsShieldsEffect : BreaksOpponentsShieldsEffect
    {
        private readonly ICard _breaker;

        public TargetCreatureBreaksOpponentsShieldsEffect(TargetCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
        {
            _breaker = effect._breaker.Copy();
        }

        public TargetCreatureBreaksOpponentsShieldsEffect(int amount, ICard breaker) : base(amount)
        {
            _breaker = breaker;
        }

        public override IOneShotEffect Copy()
        {
            return new TargetCreatureBreaksOpponentsShieldsEffect(this);
        }

        public override string ToString()
        {
            return $"{_breaker} breaks {_amount} of your opponent's shields.";
        }

        protected override ICard GetBreaker(IGame game, IAbility source)
        {
            return _breaker;
        }
    }
}