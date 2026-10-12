using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM05;

sealed class AquaSurfer : Creature
{
    public AquaSurfer() : base("Aqua Surfer", 6, 2000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddShieldTrigger();
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new BounceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCreatures
        )));
    }
}