using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class ThisCreatureBreaksOpponentsShieldsEffect : BreaksOpponentsShieldsEffect
    {
        protected ThisCreatureBreaksOpponentsShieldsEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
        {
        }

        protected ThisCreatureBreaksOpponentsShieldsEffect(int amount) : base(amount)
        {
        }

        public override string ToString()
        {
            return $"This creature breaks {_amount} of your opponent's shields.";
        }

        protected override ICard GetBreaker(IGame game, IAbility source)
        {
            return Source;
        }
    }

    class ThisCreatureBreaksOpponentsShieldEffect : ThisCreatureBreaksOpponentsShieldsEffect
    {
        public ThisCreatureBreaksOpponentsShieldEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
        {
        }

        public ThisCreatureBreaksOpponentsShieldEffect() : base(1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureBreaksOpponentsShieldEffect(this);
        }
    }

    class ThisCreatureBreaksOpponentsTwoShieldsEffect : ThisCreatureBreaksOpponentsShieldsEffect
    {
        public ThisCreatureBreaksOpponentsTwoShieldsEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
        {
        }

        public ThisCreatureBreaksOpponentsTwoShieldsEffect() : base(2)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureBreaksOpponentsTwoShieldsEffect(this);
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

        public override void Apply()
        {
            Game.Break(GetBreaker(Game, Ability), _amount);
        }

        protected abstract ICard GetBreaker(IGame game, IAbility source);
    }
}