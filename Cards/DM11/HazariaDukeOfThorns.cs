using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class HazariaDukeOfThorns : WaveStrikerCreature
{
    public HazariaDukeOfThorns() : base("Hazaria, Duke of Thorns", 4, 2000,
        Race.DarkLord, Civilization.Darkness)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: false,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}