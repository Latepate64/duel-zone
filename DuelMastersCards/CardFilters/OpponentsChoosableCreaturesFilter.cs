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

        public override bool Applies(Card card, Game game)
        {
            return game.GetOpponent(game.GetPlayer(Owner)).BattleZone.GetChoosableCreatures(game).Select(x => x.Id).Contains(card.Id);
        }

        public override CardFilter Copy()
        {
            return new OpponentsChoosableCreaturesFilter(this);
        }
    }
}
