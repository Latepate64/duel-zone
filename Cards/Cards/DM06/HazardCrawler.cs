using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Engine.Race.EarthEater, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
