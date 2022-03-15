using Engine;

namespace Cards.CardFilters
{
    class OwnersGraveyardSpellFilter : OwnersGraveyardCardFilter
    {
        public OwnersGraveyardSpellFilter()
        {
        }

        public OwnersGraveyardSpellFilter(OwnersGraveyardSpellFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && new SpellFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardSpellFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} spell";
        }
    }
}