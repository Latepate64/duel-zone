namespace Cards.OneShotEffects
{
    class ManaSpellRecoveryEffect : SelfManaRecoveryEffect
    {
        public ManaSpellRecoveryEffect(bool mandatory) : base(mandatory ? 1 : 0, 1, true, new CardFilters.OwnersManaZoneSpellFilter())
        {
        }
    }
}
