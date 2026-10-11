using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class Hurlosaur : Creature
{
    public Hurlosaur() : base("Hurlosaur", 6, 2000, Race.RockBeast,
        Civilization.Fire)
    {
        AddShieldTrigger();
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(1000),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}