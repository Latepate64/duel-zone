using Engine;

namespace Cards.CardFilters
{
    class AnotherGraveyardCardFilter : OwnersGraveyardCardFilter
    {
        public AnotherGraveyardCardFilter()
        {
        }

        public AnotherGraveyardCardFilter(AnotherGraveyardCardFilter filter) : base(filter)
        {
        }

        //public override bool Applies(Card card, Game game, IPlayer player)
        //{
        //    return base.Applies(card, game, player) && card.Id != Target;
        //}

        public override CardFilter Copy()
        {
            return new AnotherGraveyardCardFilter(this);
        }

        //public override string ToString()
        //{
        //    return $"another {ToStringBase()}";
        //}
    }
}
