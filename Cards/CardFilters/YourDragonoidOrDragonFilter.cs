using Engine;

namespace Cards.CardFilters
{
    class YourDragonoidOrDragonFilter : OwnersBattleZoneCreatureFilter
    {
        public YourDragonoidOrDragonFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && (card.HasSubtype(Common.Subtype.Dragonoid) || card.IsDragon);
        }

        public override CardFilter Copy()
        {
            return new YourDragonoidOrDragonFilter();
        }

        public override string ToString()
        {
            return "a Dragonoid or a creature that has Dragon in its race";
        }
    }
}