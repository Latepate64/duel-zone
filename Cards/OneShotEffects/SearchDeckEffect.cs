using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class SearchDeckEffect : OneShotEffect
    {
        private readonly int _maximum;

        public ICardFilter Filter { get; }

        protected SearchDeckEffect(CardFilter filter, int maximum = 1)
        {
            Filter = filter;
            _maximum = maximum;
        }

        protected SearchDeckEffect(SearchDeckEffect effect)
        {
            Filter = effect.Filter.Copy();
            _maximum = effect._maximum;
        }

        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = game.GetAllCards().Where(x => Filter.Applies(x, game, player));
            if (cards.Any())
            {
                var selectedCards = player.Choose(new BoundedCardSelectionInEffect(player.Id, cards, 0, _maximum, ToString()), game).Decision.Select(x => game.GetCard(x));
                Apply(game, source, selectedCards.ToArray());
            }
            player.ShuffleDeck(game);
            return cards.Any();
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);
    }
}
