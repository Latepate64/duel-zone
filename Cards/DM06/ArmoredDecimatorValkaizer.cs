using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class ArmoredDecimatorValkaizer : EvolutionCreature
{
    public ArmoredDecimatorValkaizer() : base("Armored Decimator Valkaizer", 5,
        5000, Race.Human, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(4000),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}