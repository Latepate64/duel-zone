using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class UntapEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        public UntapEffect(CardFilter filter)
        {
            Filter = filter;
        }

        public UntapEffect(UntapEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, player)).ToArray();
            player.Untap(game, cards);
        }

        public override OneShotEffect Copy()
        {
            return new UntapEffect(this);
        }

        public override string ToString()
        {
            return $"Untap {Filter}.";
        }
    }
}
