using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class TutoringEffect : SearchDeckEffect
    {
        public bool Reveal { get; }

        public TutoringEffect(CardFilter filter, bool reveal) : base(filter)
        {
            Reveal = reveal;
        }

        public TutoringEffect(TutoringEffect effect) : base(effect)
        {
            Reveal = effect.Reveal;
        }

        public override OneShotEffect Copy()
        {
            return new TutoringEffect(this);
        }

        public override string ToString()
        {
            var reveal = Reveal ? ", show it to your opponent," : "";
            return $"Search your deck. You may take {Filter}{reveal} and put it into your hand. Then shuffle your deck.";
        }

        protected override void Apply(Game game, Ability source, params Card[] cards)
        {
            if (Reveal)
            {
                foreach (var card in cards)
                {
                    game.GetOwner(card).Reveal(game, card);
                }
            }
            game.Move(Common.ZoneType.Deck, Common.ZoneType.Hand, cards);
        }
    }
}
