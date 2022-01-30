using Engine;

namespace Cards.CardFilters
{
    class OwnersGraveyardCardFilter : CardFilter
    {
        public OwnersGraveyardCardFilter()
        {
        }

        public OwnersGraveyardCardFilter(OwnersGraveyardCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && player != null && player.Graveyard.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardCardFilter(this);
        }
    }
}
