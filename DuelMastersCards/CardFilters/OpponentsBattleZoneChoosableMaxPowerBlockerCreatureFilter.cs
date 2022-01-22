using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter : OpponentsBattleZoneChoosableMaxPowerCreatureFilter
    {
        public OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(int power) : base(power)
        {
        }

        public OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Abilities.OfType<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(this);
        }
    }
}
