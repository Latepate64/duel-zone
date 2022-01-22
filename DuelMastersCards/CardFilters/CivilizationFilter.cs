using DuelMastersModels;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class CivilizationFilter : CardFilter
    {
        public IEnumerable<Civilization> Civilizations { get; }

        public CivilizationFilter(params Civilization[] civilizations)
        {
            Civilizations = civilizations;
        }

        public CivilizationFilter(CivilizationFilter filter) : base(filter)
        {
            Civilizations = filter.Civilizations;
        }

        public override bool Applies(Card card, Game game, System.Guid player)
        {
            return card.Civilizations.Intersect(Civilizations).Any();
        }

        public override CardFilter Copy()
        {
            return new CivilizationFilter(this);
        }
    }
}
