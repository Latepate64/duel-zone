using Common;

namespace Cards.Cards.DM12
{
    class ExtremeCrawler : Creature
    {
        public ExtremeCrawler() : base("Extreme Crawler", 5, 7000, Subtype.EarthEater, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.BounceAreaOfEffect(new CardFilters.OwnersBattleZoneCreatureFilter())), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
