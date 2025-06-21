using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ThrashCrawler : Engine.Creature
    {
        public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Engine.Race.EarthEater, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
