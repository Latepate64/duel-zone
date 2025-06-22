using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class EnchantedSoil : Spell
{
    public EnchantedSoil() : base("Enchanted Soil", 4, Civilization.Nature)
    {
        AddSpellAbilities(new EnchantedSoilEffect());
    }
}
