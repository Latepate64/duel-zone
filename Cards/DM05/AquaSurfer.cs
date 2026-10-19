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
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.AllCards
        )));
    }
}