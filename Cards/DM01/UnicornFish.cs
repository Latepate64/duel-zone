using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class UnicornFish : Creature
{
    public UnicornFish() : base("Unicorn Fish", 4, 1000, Race.Fish,
        Civilization.Water)
    {
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