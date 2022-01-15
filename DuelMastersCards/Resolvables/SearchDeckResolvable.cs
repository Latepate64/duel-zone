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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            var player = duel.GetPlayer(Controller);
            if (decision == null)
            {
                var cards = player.Deck.Cards.Where(x => Filter.Applies(x, duel));
                if (cards.Any())
                {
                    return new GuidSelection(player.Id, cards, 0, 1);
                }
                else
                {
                    player.ShuffleDeck(duel);
                    return null;
                }
            }
            else
            {
                var cards = (decision as GuidDecision).Decision.Select(x => duel.GetCard(x));
                _ = duel.Move(cards, DuelMastersModels.Zones.ZoneType.Deck, DuelMastersModels.Zones.ZoneType.Hand);

                if (Reveal)
                {
                    foreach (var card in cards)
                    {
                        duel.GetOwner(card).Reveal(duel, card);
                    }
                }
                player.ShuffleDeck(duel);
                return null;
            }
        }
    }
}
