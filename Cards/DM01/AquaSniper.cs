using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

sealed class AquaSniper : Creature
{
    public AquaSniper() : base("Aqua Sniper", 8, 5000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new BounceEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCreatures
        )));
    }
}