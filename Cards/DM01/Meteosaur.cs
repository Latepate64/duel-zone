using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class Meteosaur : Creature
{
    public Meteosaur() : base("Meteosaur", 5, 2000, Race.RockBeast,
        Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(2000),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}