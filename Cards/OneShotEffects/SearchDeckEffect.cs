using Common;
using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    class SearchDeckEffect : OneShotEffect
    {
        public CardFilter Filter { get; }
        public bool Reveal { get; }

        public SearchDeckEffect(CardFilter filter, bool reveal)
        {
            Filter = filter;
            Reveal = reveal;
        }

        public SearchDeckEffect(SearchDeckEffect effect)
        {
            Filter = effect.Filter;
            Reveal = effect.Reveal;
        }

        public override OneShotEffect Copy()
        {
            return new SearchDeckEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = player.Deck.Cards.Where(x => Filter.Applies(x, game, player));
            if (cards.Any())
            {
                var decision = player.Choose(new BoundedCardSelectionInEffect(player.Id, cards, 0, 1, ToString()), game);
                var selectedCards = decision.Decision.Select(x => game.GetCard(x));
                if (Reveal)
                {
                    foreach (var card in selectedCards)
                    {
                        game.GetOwner(card).Reveal(game, card);
                    }
                }
                game.Move(ZoneType.Deck, ZoneType.Hand, selectedCards.ToArray());
            }
            player.ShuffleDeck(game);
        }

        public override string ToString()
        {
            var reveal = Reveal ? ", show it to your opponent," : "";
            return $"Search your deck. You may take {Filter}{reveal} and put it into your hand. Then shuffle your deck.";
        }
    }
}
