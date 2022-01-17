using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class ReturnCardsFromGraveyardToHandResolvable : Resolvable
    {
        public int Maximum { get; }
        CardFilter Filter { get; }

        public ReturnCardsFromGraveyardToHandResolvable(int maximum, CardFilter filter)
        {
            Maximum = maximum;
            Filter = filter;
        }

        public ReturnCardsFromGraveyardToHandResolvable(ReturnCardsFromGraveyardToHandResolvable resolvable) : base(resolvable)
        {
            Maximum = resolvable.Maximum;
            Filter = resolvable.Filter;
        }

        public override Resolvable Copy()
        {
            return new ReturnCardsFromGraveyardToHandResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var cards = player.Graveyard.Cards.Where(x => Filter.Applies(x, duel));
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, cards, 0, Maximum));
                duel.Move(decision.Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Graveyard, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
