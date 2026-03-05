using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class ExtremeCrawler : Creature
{
    public ExtremeCrawler() : base("Extreme Crawler", 5, 7000, Race.EarthEater, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ExtremeCrawlerEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
