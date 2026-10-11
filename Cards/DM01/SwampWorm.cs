using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class SwampWorm : Creature
{
    public SwampWorm() : base("Swamp Worm", 7, 2000, Race.ParasiteWorm,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
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