using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class PhantomDragonsFlame : Spell
{
    public PhantomDragonsFlame() : base("Phantom Dragon's Flame", 3,
        Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(2000),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}