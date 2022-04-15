namespace Cards.Cards.DM03
{
    class LenaVizierOfBrilliance : Creature
    {
        public LenaVizierOfBrilliance() : base("Lena, Vizier of Brilliance", 4, 2000, Engine.Subtype.Initiate, Common.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect());
        }
    }
}
