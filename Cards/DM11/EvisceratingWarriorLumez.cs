using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class EvisceratingWarriorLumez : WaveStrikerCreature
{
    public EvisceratingWarriorLumez() : base("Eviscerating Warrior Lumez", 3,
        2000, Race.Armorloid, Civilization.Fire)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    filter: new MaxPowerFilter(2000),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false)));
    }
}