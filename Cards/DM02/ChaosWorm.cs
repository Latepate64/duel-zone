using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class ChaosWorm : EvolutionCreature
{
    public ChaosWorm() : base("Chaos Worm", 5, 5000, Race.ParasiteWorm,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}