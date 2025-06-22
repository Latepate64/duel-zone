using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class HurricaneCrawler : Creature
{
    public HurricaneCrawler() : base("Hurricane Crawler", 5, 4000, Race.EarthEater, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new HurricaneCrawlerEffect()));
    }
}
