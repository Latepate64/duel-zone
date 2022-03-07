namespace Cards.OneShotEffects
{
    class OpponentSacrificeEffect : DestroyEffect
    {
        public OpponentSacrificeEffect() : base(new CardFilters.OpponentsBattleZoneCreatureFilter(), 1, 1, false)
        {
        }
    }
}
