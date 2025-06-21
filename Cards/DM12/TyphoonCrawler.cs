namespace Cards.DM12
{
    class TyphoonCrawler : Engine.Creature
    {
        public TyphoonCrawler() : base("Typhoon Crawler", 6, 5000, Engine.Race.EarthEater, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Engine.Civilization.Fire, Engine.Civilization.Nature));
        }
    }
}
