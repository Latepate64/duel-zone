using Engine;

namespace Cards.CardFilters
{
    public class TargetFilter : CardFilter
    {
        public TargetFilter()
        {
        }

        public TargetFilter(TargetFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new TargetFilter(this);
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return Target == card?.Id;
        }

        public override string ToString()
        {
            return "this creature";
        }
    }
}
