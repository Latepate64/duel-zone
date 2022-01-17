using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class SearchDeckResolvable : Resolvable
    {
        public CardFilter Filter { get; }
        public bool Reveal { get; }

        public SearchDeckResolvable(CardFilter filter, bool reveal)
        {
            Filter = filter;
            Reveal = reveal;
        }

        public SearchDeckResolvable(SearchDeckResolvable resolvable) : base(resolvable)
        {
            Filter = resolvable.Filter;
            Reveal = resolvable.Reveal;
        }

        public override Resolvable Copy()
        {
            return new SearchDeckResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var cards = player.Deck.Cards.Where(x => Filter.Applies(x, duel));
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(player.Id, cards, 0, 1));
                var cards2 = decision.Decision.Select(x => duel.GetCard(x));
                duel.Move(cards2, DuelMastersModels.Zones.ZoneType.Deck, DuelMastersModels.Zones.ZoneType.Hand);

                if (Reveal)
                {
                    foreach (var card in cards2)
                    {
                        duel.GetOwner(card).Reveal(duel, card);
                    }
                }
            }
            player.ShuffleDeck(duel);
        }
    }
}
