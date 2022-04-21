using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DrawCardsEffect : OneShotEffect
    {
        private readonly int _amount;

        public DrawCardsEffect(int amount)
        {
            _amount = amount;
        }

        public DrawCardsEffect(DrawCardsEffect effect)
        {
            _amount = effect._amount;
        }

        public override void Apply(IGame game)
        {
            Controller.DrawCards(_amount, game, Source);
        }

        public override IOneShotEffect Copy()
        {
            return new DrawCardsEffect(this);
        }

        public override string ToString()
        {
            return $"Draw {_amount} cards.";
        }
    }
}