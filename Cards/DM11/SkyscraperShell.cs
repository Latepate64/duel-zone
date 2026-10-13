using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class SkyscraperShell : WaveStrikerCreature
{
    public SkyscraperShell() : base("Skyscraper Shell", 4, 2000,
        Race.ColonyBeetle, Civilization.Nature)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: false,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OwnCreatures
        )));
    }
}