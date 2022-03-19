using Engine;

namespace Cards.CardFilters
{
    abstract class BattleZoneCardFilter : CardFilter
    {
        public BattleZoneCardFilter() : base()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return game.BattleZone.Cards.Contains(card);
        }
    }
}
