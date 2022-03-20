using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    internal class DrawEffect : OneShotEffect
    {
        private int _amount;

        public DrawEffect(int amount)
        {
            _amount = amount;
        }

        public DrawEffect(DrawEffect effect)
        {
            _amount = effect._amount;
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.GetPlayer(source.Owner).DrawCards(_amount, game);
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new DrawEffect(this);
        }

        public override string ToString()
        {
            return $"Draw {_amount} cards.";
        }
    }
}