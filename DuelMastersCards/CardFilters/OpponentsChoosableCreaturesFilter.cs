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
            var opponent = game.GetOpponent(game.GetPlayer(Owner));
            if (opponent != null)
            {
                return opponent.BattleZone.GetChoosableCreatures(game).Select(x => x.Id).Contains(card.Id);
            }
            else
            {
                return false;
            }
        }

        public override CardFilter Copy()
        {
            return new OpponentsChoosableCreaturesFilter(this);
        }
    }
}
