using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DrawThenDiscardEffect : OneShotEffect
    {
        private readonly int _discard;

        public DrawThenDiscardEffect(DrawThenDiscardEffect effect)
        {
            _discard = effect._discard;
        }

        public DrawThenDiscardEffect(int discard)
        {
            _discard = discard;
        }

        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new YouMayDrawCardsEffect(2), new DiscardCardFromYourHandEffect() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new DrawThenDiscardEffect(this);
        }

        public override string ToString()
        {
            var amount = _discard == 1 ? "a card" : $"{_discard} cards";
            return $"Draw up to 2 cards. Then discard {amount} from your hand.";
        }
    }
}
