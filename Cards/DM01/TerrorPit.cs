using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class TerrorPit : Spell
{
    public TerrorPit() : base("Terror Pit", 6, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}