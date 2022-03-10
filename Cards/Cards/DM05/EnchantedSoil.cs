using Common;

namespace Cards.Cards.DM05
{
    class EnchantedSoil : Spell
    {
        public EnchantedSoil() : base("Enchanted Soil", 4, Civilization.Nature)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.FromGraveyardIntoManaZoneEffect(new CardFilters.OwnersGraveyardCardFilter { CardType = CardType.Creature }, 0, 2, true)));
        }
    }
}
