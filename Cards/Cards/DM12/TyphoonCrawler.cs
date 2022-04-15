namespace Cards.Cards.DM12
{
    class TyphoonCrawler : Creature
    {
        public TyphoonCrawler() : base("Typhoon Crawler", 6, 5000, Engine.Subtype.EarthEater, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Engine.Civilization.Fire, Engine.Civilization.Nature));
        }
    }
}
