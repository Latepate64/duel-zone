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

        public BattleZoneChoosableCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            if (base.Applies(card, game, player))
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
            else
            {
                return false;
            }
        }

        public override CardFilter Copy()
        {
            return new BattleZoneChoosableCreatureFilter(this);
        }

        public override string ToString()
        {
            return ToStringBase();
        }
    }
}
