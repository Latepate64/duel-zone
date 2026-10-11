using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class SpasticMissile : Spell
{
    public SpasticMissile() : base("Spastic Missile", 3, Civilization.Fire)
    {
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(3000),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}