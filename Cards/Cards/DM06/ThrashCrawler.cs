using Common;

namespace Cards.Cards.DM06
{
    class ThrashCrawler : Creature
    {
        public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Subtype.EarthEater, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(1)), new StaticAbilities.ThisCreatureCannotAttackAbility());
        }
    }
}
