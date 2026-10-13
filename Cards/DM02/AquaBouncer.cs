using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;
using Interfaces;
using CardFilters;

namespace Cards.DM02;

sealed class AquaBouncer : Creature
{
    public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddAbilities(new BlockerAbility());
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