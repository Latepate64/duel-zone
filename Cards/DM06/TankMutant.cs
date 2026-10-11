using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class TankMutant : Creature
{
    public TankMutant() : base("Tank Mutant", 9, 6000, Race.Hedrian,
        Civilization.Darkness)
    {
        AddAbilities(
            new TapAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: false,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}