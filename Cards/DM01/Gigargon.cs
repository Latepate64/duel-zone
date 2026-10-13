using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

sealed class Gigargon : Creature
{
    public Gigargon() : base("Gigargon", 8, 3000, Race.Chimera,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCards
        )));
    }
}