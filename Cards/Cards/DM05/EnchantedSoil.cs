using Common;

namespace Cards.Cards.DM05
{
    class EnchantedSoil : Spell
    {
        public EnchantedSoil() : base("Enchanted Soil", 4, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.FromGraveyardIntoManaZoneEffect(new CardFilters.OwnersGraveyardCreatureFilter(), 0, 2, true));
        }
    }
}
