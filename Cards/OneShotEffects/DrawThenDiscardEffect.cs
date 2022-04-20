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

        public override void Apply(IGame game, IAbility source)
        {
            var controller = source.GetController(game);
            controller.DrawCardsOptionally(game, source, 2);
            controller.DiscardOwnCards(game, source, _discard);
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
