using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class BlockerFilter : CardFilter
    {
        public BlockerFilter()
        {
        }

        public BlockerFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, System.Guid player)
        {
            return card.Abilities.OfType<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new BlockerFilter(this);
        }
    }
}
