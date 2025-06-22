using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class ThrashCrawler : Engine.Creature
    {
        public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
