using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class StormShell : Creature
{
    public StormShell() : base("Storm Shell", 7, 2000, Race.ColonyBeetle,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaFeedEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: false,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OwnCreatures
        )));
    }
}