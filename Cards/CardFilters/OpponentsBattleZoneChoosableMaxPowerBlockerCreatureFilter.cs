using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter : OpponentsBattleZoneChoosableMaxPowerCreatureFilter
    {
        public OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(int power) : base(power)
        {
        }

        public OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter filter) : base(filter.PowerFilter.Number)
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.GetAbilities<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + " and has \"blocker\"";
        }
    }
}
