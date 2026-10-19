using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;
using CardFilters;

namespace Cards.DM12;

public sealed class ExtremeCrawler : Creature
{
    public ExtremeCrawler() : base("Extreme Crawler", 5, 7000, Race.EarthEater,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Hand,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCards,
                    excludeSource: true
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
