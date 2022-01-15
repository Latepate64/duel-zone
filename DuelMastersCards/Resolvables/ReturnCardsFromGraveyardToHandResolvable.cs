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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var cards = duel.GetPlayer(Controller).Graveyard.Cards.Where(x => Filter.Applies(x, duel));
                if (cards.Any())
                {
                    return new GuidSelection(Controller, cards, 0, Maximum);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return duel.Move((decision as GuidDecision).Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Graveyard, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
