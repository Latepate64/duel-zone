namespace Cards.Cards.DM03
{
    class LenaVizierOfBrilliance : Creature
    {
        public LenaVizierOfBrilliance() : base("Lena, Vizier of Brilliance", 4, 2000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect()));
        }
    }
}
