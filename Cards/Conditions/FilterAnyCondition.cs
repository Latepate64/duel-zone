using Engine;
using System.Linq;

namespace Cards.Conditions
{
    /// <summary>
    /// Checks that filter produces at least one item.
    /// </summary>
    class FilterAnyCondition : Condition
    {
        internal CardFilter Filter { get; set; }

        internal FilterAnyCondition(CardFilter filter)
        {
            Filter = filter;
        }

        public override bool Applies(Game game, System.Guid player)
        {
            return game.GetAllCards().Any(card => Filter.Applies(card, game, game.GetPlayer(player)));
        }

        public override string ToString()
        {
            return $"While any of {Filter} exists";
        }
    }
}
