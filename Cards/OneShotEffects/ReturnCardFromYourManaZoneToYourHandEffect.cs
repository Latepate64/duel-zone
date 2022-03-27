namespace Cards.OneShotEffects
{
    class ReturnCardFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCardFromYourManaZoneToYourHandEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneCardFilter())
        {
        }
    }
}
