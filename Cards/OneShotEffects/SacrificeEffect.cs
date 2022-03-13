using Engine;

namespace Cards.OneShotEffects
{
    class SacrificeEffect : DestroyEffect
    {
        public SacrificeEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public SacrificeEffect(CardFilter filter, bool mandatory) : base(new CardFilters.OwnersBattleZoneCreatureFilter(), mandatory ? 1 : 0, 1, true)
        {
        }
    }
}
