using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class MidnightCrawler : Creature
    {
        public MidnightCrawler() : base("Midnight Crawler", 8, 6000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
