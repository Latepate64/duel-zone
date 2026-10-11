using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

sealed class FlameTrooperGoliac : WaveStrikerCreature
{
    public FlameTrooperGoliac() : base("Flame Trooper Goliac", 5, 4000,
        Race.Armorloid, Civilization.Fire)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(5000),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}