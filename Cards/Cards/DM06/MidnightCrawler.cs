using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class MidnightCrawler : Engine.Creature
    {
        public MidnightCrawler() : base("Midnight Crawler", 8, 6000, Engine.Race.EarthEater, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
