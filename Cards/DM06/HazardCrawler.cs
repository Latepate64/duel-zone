using ContinuousEffects;

namespace Cards.DM06
{
    sealed class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
