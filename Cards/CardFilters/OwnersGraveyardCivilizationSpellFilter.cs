using Common;
using Engine;

namespace Cards.CardFilters
{
    class OwnersGraveyardCivilizationSpellFilter : OwnersGraveyardSpellFilter, ICivilizationFilterable
    {
        public OwnersGraveyardCivilizationSpellFilter(Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OwnersGraveyardCivilizationSpellFilter(OwnersGraveyardCivilizationSpellFilter filter) : base(filter)
        {
        }

        public CivilizationFilter CivilizationFilter { get; }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardCivilizationSpellFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {CivilizationFilter} spell";
        }
    }
}