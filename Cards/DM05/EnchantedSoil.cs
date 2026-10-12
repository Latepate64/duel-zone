using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class EnchantedSoil : Spell
{
    public EnchantedSoil() : base("Enchanted Soil", 4, Civilization.Nature)
    {
        AddSpellAbilities(
            new FromGraveyardIntoManaZoneEffect(
                0, 2, true, new CreatureFilter()
        ));
    }
}
