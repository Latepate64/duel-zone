using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class SolidskinFish : Creature
{
    public SolidskinFish() : base("Solidskin Fish", 3, 3000, Race.Fish,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaRecoveryEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                selectionRange: SelectionRange.OwnCreatures
        )));
    }
}