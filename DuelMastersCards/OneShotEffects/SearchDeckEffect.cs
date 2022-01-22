using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class SearchDeckEffect : OneShotEffect
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
                var decision = player.Choose(new GuidSelection(player.Id, cards, 0, 1));
                var selectedCards = decision.Decision.Select(x => game.GetCard(x));
                if (Reveal)
                {
                    foreach (var card in selectedCards)
                    {
                        game.GetOwner(card).Reveal(game, card);
                    }
                }
                game.Move(selectedCards, DuelMastersModels.Zones.ZoneType.Deck, DuelMastersModels.Zones.ZoneType.Hand);
            }
            player.ShuffleDeck(game);
        }
    }
}
