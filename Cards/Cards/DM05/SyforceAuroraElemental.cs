namespace Cards.Cards.DM05
{
    class SyforceAuroraElemental : Creature
    {
        public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000, Engine.Subtype.AngelCommand, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect());
            AddDoubleBreakerAbility();
        }
    }
}
