using ContinuousEffects;

namespace Cards.DM06
{
    class HazardCrawler : Engine.Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
