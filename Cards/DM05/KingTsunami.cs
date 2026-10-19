using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;
using CardFilters;

namespace Cards.DM05;

public sealed class KingTsunami : Creature
{
    public KingTsunami() : base("King Tsunami", 12, 12000, Race.Leviathan,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Hand,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: true
                )));
        AddAbilities(new TripleBreakerAbility());
    }
}
