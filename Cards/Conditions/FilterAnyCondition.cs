using Engine;
using System.Linq;

namespace Cards.Conditions
{
    /// <summary>
    /// Checks that filter produces at least one item.
    /// </summary>
    class FilterAnyCondition : Condition
    {
        public FilterAnyCondition(FilterAnyCondition condition) : base(condition)
        {
        }

        internal FilterAnyCondition(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Game game, System.Guid player)
        {
            return game.GetAllCards().Any(card => Filter.Applies(card, game, game.GetPlayer(player)));
        }

        public override Condition Copy()
        {
            return new FilterAnyCondition(this);
        }

        public override string ToString()
        {
            return $"While any of {Filter} exists";
        }
    }
}
