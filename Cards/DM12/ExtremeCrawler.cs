using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM12;

public sealed class ExtremeCrawler : Creature
{
    public ExtremeCrawler() : base("Extreme Crawler", 5, 7000, Race.EarthEater, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ExtremeCrawlerEffect()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
