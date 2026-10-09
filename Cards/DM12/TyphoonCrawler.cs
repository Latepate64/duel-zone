using ContinuousEffects.CannotBeAttacked;

namespace Cards.DM12
{
    sealed class TyphoonCrawler : Creature
    {
        public TyphoonCrawler() : base("Typhoon Crawler", 6, 5000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Interfaces.Civilization.Fire, Interfaces.Civilization.Nature));
        }
    }
}
