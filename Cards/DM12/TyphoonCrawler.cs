using CardFilters;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

sealed class TyphoonCrawler : Creature
{
    public TyphoonCrawler() : base("Typhoon Crawler", 6, 5000, Race.EarthEater, Civilization.Water)
    {
        AddStaticAbilities(
            new ThisCreatureCannotBeAttackedEffect(
                new CivilizationCreatureFilter(
                    Civilization.Fire,
                    Civilization.Nature)));
    }
}