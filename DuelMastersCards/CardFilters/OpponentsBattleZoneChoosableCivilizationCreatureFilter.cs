using DuelMastersModels;
using DuelMastersModels.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class OpponentsBattleZoneChoosableCivilizationCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public IEnumerable<Civilization> Civilizations { get; }

        public OpponentsBattleZoneChoosableCivilizationCreatureFilter(params Civilization[] civilizations)
        {
            Civilizations = civilizations;
        }

        public OpponentsBattleZoneChoosableCivilizationCreatureFilter(OpponentsBattleZoneChoosableCivilizationCreatureFilter filter) : base(filter)
        {
            Civilizations = filter.Civilizations;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Civilizations.Intersect(Civilizations).Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableCivilizationCreatureFilter(this);
        }
    }
}
