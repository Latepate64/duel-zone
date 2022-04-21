using Engine;
using Engine.Abilities;
using System.Linq;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class SearchAnyDeckEffect : OneShotEffect
    {
        private readonly int _maximum;
        private readonly bool _searchOpponentsDeck;

        protected SearchAnyDeckEffect(int maximum = 1, bool searchOpponentsDeck = false)
        {
            _maximum = maximum;
            _searchOpponentsDeck = searchOpponentsDeck;
        }

        protected SearchAnyDeckEffect(SearchAnyDeckEffect effect)
        {
            _maximum = effect._maximum;
            _searchOpponentsDeck = effect._searchOpponentsDeck;
        }

        public override void Apply(IGame game, IAbility source)
        {
            var cards = GetAffectedCards(game, source);
            if (cards.Any())
            {
                var selectedCards = GetController(game).ChooseCards(cards, 0, _maximum, ToString());
                Apply(game, source, selectedCards.ToArray());
            }
            (_searchOpponentsDeck ? GetOpponent(game) : GetController(game)).ShuffleDeck(game);
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
