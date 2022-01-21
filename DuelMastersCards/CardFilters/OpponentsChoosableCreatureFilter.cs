using DuelMastersModels;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class OpponentsChoosableCreatureFilter : CardFilter
    {
        public OpponentsChoosableCreatureFilter()
        {
        }

        public OpponentsChoosableCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game)
        {
            var opponent = game.GetOpponent(game.GetPlayer(Owner));
            if (opponent != null)
            {
                return game.BattleZone.GetChoosableCreatures(game, opponent.Id).Select(x => x.Id).Contains(card.Id);
            }
            else
            {
                return false;
            }
        }

        public override CardFilter Copy()
        {
            return new OpponentsChoosableCreatureFilter(this);
        }
    }
}
