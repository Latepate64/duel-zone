using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneChoosableCreatureFilter()
        {
        }

        public OpponentsBattleZoneChoosableCreatureFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && !game.GetContinuousEffects<UnchoosableEffect>(card).Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"of your opponent's {ToStringBase()}s";
        }
    }
}
