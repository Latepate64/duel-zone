namespace Cards.Cards.DM06
{
    class MidnightCrawler : Creature
    {
        public MidnightCrawler() : base("Midnight Crawler", 8, 6000, Engine.Subtype.EarthEater, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect());
            AddDoubleBreakerAbility();
        }
    }
}
