using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ThrashCrawler : Creature
    {
        public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Engine.Race.EarthEater, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
