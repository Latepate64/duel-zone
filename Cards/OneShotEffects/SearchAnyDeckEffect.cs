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

        public override void Apply()
        {
            var cards = GetAffectedCards(Ability);
            if (cards.Any())
            {
                var selectedCards = Applier.ChooseCards(cards, 0, _maximum, ToString());
                Apply(Ability, selectedCards.ToArray());
            }
            (_searchOpponentsDeck ? Applier.Opponent : Applier).ShuffleOwnDeck();
        }

        protected abstract void Apply(IAbility source, params ICard[] cards);

        protected abstract IEnumerable<ICard> GetAffectedCards(IAbility source);
    }
}
