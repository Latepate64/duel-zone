using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class PalaOlesisFilter : CardFilter
    {
        public PalaOlesisFilter()
        {
        }

        public PalaOlesisFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            // During your opponent's turn, each of your other creatures
            return base.Applies(card, game, player) && card != null && game.CurrentTurn.NonActivePlayer.Id == player.Id && game.BattleZone.GetCreatures(player.Id).Contains(card) && card.Id != Target;
        }

        public override CardFilter Copy()
        {
            return new PalaOlesisFilter(this);
        }

        public override string ToString()
        {
            return "each of your other creatures";
        }
    }
}
