using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class TutoringEffect : SearchDeckEffect
    {
        public bool Reveal { get; }

        public TutoringEffect(CardFilter filter, bool reveal, int maximum = 1) : base(filter, maximum)
        {
            Reveal = reveal;
        }

        public TutoringEffect(TutoringEffect effect) : base(effect)
        {
            Reveal = effect.Reveal;
        }

        public override IOneShotEffect Copy()
        {
            return new TutoringEffect(this);
        }

        public override string ToString()
        {
            var reveal = Reveal ? ", show it to your opponent," : "";
            return $"Search your deck. You may take {Filter}{reveal} and put it into your hand. Then shuffle your deck.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (Reveal)
            {
                game.GetPlayer(source.Owner).Reveal(game, cards);
            }
            game.Move(Common.ZoneType.Deck, Common.ZoneType.Hand, cards);
            if (Reveal)
            {
                game.GetPlayer(source.Owner)?.Unreveal(cards);
            }
        }
    }
}
