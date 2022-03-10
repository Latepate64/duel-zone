using Engine;

namespace Cards.CardFilters
{
    abstract class BattleZoneCardFilter : CardFilter
    {
        public BattleZoneCardFilter(params Common.Civilization[] civilizations) : base(civilizations)
        {
        }

        public BattleZoneCardFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.BattleZone.Cards.Contains(card);
        }
    }
}
