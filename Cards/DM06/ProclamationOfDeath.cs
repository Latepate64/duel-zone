using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class ProclamationOfDeath : Spell
{
    public ProclamationOfDeath() : base("Proclamation of Death", 4,
        Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: false,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OwnCreatures
            ));
    }
}