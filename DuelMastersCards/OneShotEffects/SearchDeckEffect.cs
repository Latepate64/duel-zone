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
            var cards = player.Deck.Cards.Where(x => Filter.Applies(x, game, source.Owner));
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(player.Id, cards, 0, 1));
                var cards2 = decision.Decision.Select(x => game.GetCard(x));
                game.Move(cards2, DuelMastersModels.Zones.ZoneType.Deck, DuelMastersModels.Zones.ZoneType.Hand);

                if (Reveal)
                {
                    foreach (var card in cards2)
                    {
                        game.GetOwner(card).Reveal(game, card);
                    }
                }
            }
            player.ShuffleDeck(game);
        }
    }
}
