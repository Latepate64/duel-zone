using Common;

namespace Cards.Cards.DM12
{
    class TyphoonCrawler : Creature
    {
        public TyphoonCrawler() : base("Typhoon Crawler", 6, 5000, Engine.Subtype.EarthEater, Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Civilization.Fire, Civilization.Nature));
        }
    }
}
