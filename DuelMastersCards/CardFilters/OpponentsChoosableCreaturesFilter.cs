using DuelMastersModels;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class OpponentsChoosableCreaturesFilter : CardFilter
    {
        public OpponentsChoosableCreaturesFilter()
        {
        }

        public OpponentsChoosableCreaturesFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Duel duel)
        {
            return duel.GetOpponent(duel.GetPlayer(Owner)).BattleZone.GetChoosableCreatures(duel).Select(x => x.Id).Contains(card.Id);
        }

        public override CardFilter Copy()
        {
            return new OpponentsChoosableCreaturesFilter(this);
        }
    }
}
