using Engine;

namespace Cards.CardFilters
{
    public class AnyFilter : CardFilter
    {
        public AnyFilter()
        {
        }

        public AnyFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && true;
        }

        public override CardFilter Copy()
        {
            return new AnyFilter(this);
        }
    }
}
