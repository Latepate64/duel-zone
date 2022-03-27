using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class SearchAnyDeckEffect : OneShotEffect
    {
        private readonly int _maximum;
        private readonly bool _searchOpponentsDeck;

        public ICardFilter Filter { get; }

        protected SearchAnyDeckEffect(CardFilter filter, int maximum = 1, bool searchOpponentsDeck = false)
        {
            Filter = filter;
            _maximum = maximum;
            _searchOpponentsDeck = searchOpponentsDeck;
        }

        protected SearchAnyDeckEffect(SearchAnyDeckEffect effect)
        {
            Filter = effect.Filter.Copy();
            _maximum = effect._maximum;
            _searchOpponentsDeck = effect._searchOpponentsDeck;
        }

        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Controller);
            var deckOwner = _searchOpponentsDeck ? game.GetOpponent(player) : player;
            var cards = game.GetAllCards().Where(x => Filter.Applies(x, game, player));
            if (cards.Any())
            {
                var selectedCards = player.Choose(new BoundedCardSelectionInEffect(player.Id, cards, 0, _maximum, ToString()), game).Decision.Select(x => game.GetCard(x));
                Apply(game, source, selectedCards.ToArray());
            }
            deckOwner.ShuffleDeck(game);
            return cards.Any();
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);
    }
}
