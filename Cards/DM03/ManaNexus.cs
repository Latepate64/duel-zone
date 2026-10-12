using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class ManaNexus : Spell
{
    public ManaNexus() : base("Mana Nexus", 4, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new FromManaZoneToShieldsFaceDownEffect(
                new AnyCardFilter()
            ));
    }
}