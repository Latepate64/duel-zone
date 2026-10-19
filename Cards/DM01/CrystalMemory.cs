using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class CrystalMemory : Spell
{
    public CrystalMemory() : base("Crystal Memory", 4, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new SearchEffect(
                reveal: false,
                filter: new AnyCardFilter()
        ));
    }
}