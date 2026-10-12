using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

sealed class MorbidMedicine : Spell
{
    public MorbidMedicine() : base("Morbid Medicine", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new SalvageEffect(
                minimum: 0,
                maximum: 2,
                filter: new CreatureFilter(),
                excludeSource: false
        ));
    }
}