using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class DimensionGate : Spell
{
    public DimensionGate() : base("Dimension Gate", 3, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new SearchEffect(
                reveal: true,
                filter: new CreatureFilter()
        ));
    }
}