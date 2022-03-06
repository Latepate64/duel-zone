namespace Cards.OneShotEffects
{
    class SacrificeEffect : DestroyEffect
    {
        public SacrificeEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }
    }
}
