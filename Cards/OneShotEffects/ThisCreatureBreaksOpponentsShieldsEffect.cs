using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ThisCreatureBreaksOpponentsShieldsEffect : OneShotEffect
    {
        private readonly int _amount;

        public ThisCreatureBreaksOpponentsShieldsEffect(ThisCreatureBreaksOpponentsShieldsEffect effect)
        {
            _amount = effect._amount;
        }

        public ThisCreatureBreaksOpponentsShieldsEffect(int amount = 1)
        {
            _amount = amount;
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.GetCard(source.Source).Break(game, _amount);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureBreaksOpponentsShieldsEffect(this);
        }

        public override string ToString()
        {
            return $"This creature breaks {_amount} of your opponent's shields.";
        }
    }
}