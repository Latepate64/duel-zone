using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class ThrumissZephyrGuardian : Creature
{
    public ThrumissZephyrGuardian() : base("Thrumiss, Zephyr Guardian", 6, 3000,
        Race.Guardian, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverAnyOfYourCreaturesAttacksAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}