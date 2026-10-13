using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class BlizzardOfSpears : Spell
{
    public BlizzardOfSpears() : base("Blizzard of Spears", 6, Civilization.Fire)
    {
        AddSpellAbilities(
            new DestroyAreaOfEffect(
                    filter: new MaxPowerFilter(4000),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false));
    }
}