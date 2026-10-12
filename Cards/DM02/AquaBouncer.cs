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
                new BounceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCreatures
        )));
    }
}