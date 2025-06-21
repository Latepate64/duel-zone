namespace Cards.DM12
{
    class TyphoonCrawler : Engine.Creature
    {
        public TyphoonCrawler() : base("Typhoon Crawler", 6, 5000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Interfaces.Civilization.Fire, Interfaces.Civilization.Nature));
        }
    }
}
