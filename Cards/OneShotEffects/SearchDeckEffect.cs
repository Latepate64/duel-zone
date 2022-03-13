using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class SearchDeckEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        protected SearchDeckEffect(CardFilter filter)
        {
            Filter = filter;
        }

        protected SearchDeckEffect(SearchDeckEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        public override object Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = game.GetAllCards().Where(x => Filter.Applies(x, game, player));
            if (cards.Any())
            {
                var selectedCards = player.Choose(new BoundedCardSelectionInEffect(player.Id, cards, 0, 1, ToString()), game).Decision.Select(x => game.GetCard(x));
                Apply(game, source, selectedCards.ToArray());
            }
            player.ShuffleDeck(game);
            return cards.Any();
        }

        protected abstract void Apply(Game game, Ability source, params Card[] cards);
    }
}
