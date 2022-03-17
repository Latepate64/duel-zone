using Engine;
using System;
using System.Linq;

namespace Cards.CardFilters
{
    class BattleZoneChoosableCreatureFilter : CardFilter
    {
        public BattleZoneChoosableCreatureFilter()
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            var ownerApplies = game.BattleZone.GetCreatures(player.Id).Select(x => x.Id).Contains(card.Id);
            var opponent = game.GetOpponent(player);
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
            return new BattleZoneChoosableCreatureFilter();
        }

        public override string ToString()
        {
            return "creatures";
        }
    }
}
