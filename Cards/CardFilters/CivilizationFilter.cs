using Common;
using Engine;
using System.Collections.Generic;
using System.Linq;

namespace Cards.CardFilters
{
    sealed class CivilizationFilter : CardFilter
    {
        public List<Civilization> Civilizations { get; } = new List<Civilization>();

        public CivilizationFilter(params Civilization[] civilizations) : base()
        {
            Civilizations.AddRange(civilizations);
        }

        public CivilizationFilter(CivilizationFilter filter) : base()
        {
            Civilizations = filter.Civilizations;
        }

        public override CardFilter Copy()
        {
            return new CivilizationFilter(this);
        }

        public override string ToString()
        {
            return string.Join("/", Civilizations);
        }

        public override bool Applies(Engine.Card card, Game game, Engine.Player player)
        {
            return !Civilizations.Any() || card.Civilizations.Intersect(Civilizations).Any();
        }
    }

    interface ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }
    }
}
