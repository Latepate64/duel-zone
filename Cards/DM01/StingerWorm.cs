using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class StingerWorm : Creature
{
    public StingerWorm() : base("Stinger Worm", 3, 5000, Race.ParasiteWorm,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}