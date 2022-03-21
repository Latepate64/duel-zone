using Common;
using Engine;

namespace Cards.CardFilters
{
    class OwnersDeckCivilizationCreatureFilter : OwnersDeckCivilizationCardFilter
    {
        public OwnersDeckCivilizationCreatureFilter(Civilization civilization) : base(civilization)
        {
        }

        public OwnersDeckCivilizationCreatureFilter(OwnersDeckCivilizationCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCivilizationCreatureFilter(this);
        }
    }
}