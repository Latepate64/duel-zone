using DuelMastersModels;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class PalaOlesisFilter : CardFilter
    {
        public PalaOlesisFilter()
        {
        }

        public PalaOlesisFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Duel duel)
        {
            // During your opponent's turn, each of your other creatures
            return duel.CurrentTurn.NonActivePlayer == Owner && duel.GetPlayer(Owner).BattleZone.Creatures.Contains(card) && card.Id != Target;
        }

        public override CardFilter Copy()
        {
            return new PalaOlesisFilter(this);
        }
    }
}
