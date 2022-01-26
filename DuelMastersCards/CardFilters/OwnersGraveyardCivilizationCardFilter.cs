using DuelMastersModels;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class OwnersGraveyardCivilizationCardFilter : OwnersGraveyardCardFilter
    {
        public IEnumerable<Civilization> Civilizations { get; }

        public OwnersGraveyardCivilizationCardFilter(params Civilization[] civilizations)
        {
            Civilizations = civilizations;
        }

        public OwnersGraveyardCivilizationCardFilter(OwnersGraveyardCivilizationCardFilter filter) : base(filter)
        {
            Civilizations = filter.Civilizations;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Civilizations.Intersect(Civilizations).Any();
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardCivilizationCardFilter(this);
        }
    }
}
