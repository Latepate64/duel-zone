using DuelMastersModels;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class ChoosableCreatureFilter : CardFilter
    {
        public ChoosableCreatureFilter()
        {
        }

        public ChoosableCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Guid player)
        {
            var owner = game.GetPlayer(player);
            var ownerApplies = game.BattleZone.GetCreatures(player).Select(x => x.Id).Contains(card.Id);
            var opponent = game.GetOpponent(owner);
            if (opponent != null)
            {
                return game.BattleZone.GetCreatures(opponent.Id).Select(x => x.Id).Contains(card.Id) || ownerApplies;
            }
            else
            {
                return ownerApplies;
            }
        }

        public override CardFilter Copy()
        {
            return new OpponentsChoosableCreatureFilter(this);
        }
    }
}
