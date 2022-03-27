using Common;

namespace Cards.Cards.DM06
{
    class MidnightCrawler : Creature
    {
        public MidnightCrawler() : base("Midnight Crawler", 8, 6000, Subtype.EarthEater, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
