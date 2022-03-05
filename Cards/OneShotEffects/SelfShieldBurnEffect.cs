namespace Cards.OneShotEffects
{
    class SelfShieldBurnEffect : ShieldBurnEffect
    {
        public SelfShieldBurnEffect() : base(new CardFilters.OwnersShieldZoneCardFilter(), 1, 1, true) { }
    }
}
