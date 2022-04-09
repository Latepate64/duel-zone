using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM05
{
    class EnchantedSoil : Spell
    {
        public EnchantedSoil() : base("Enchanted Soil", 4, Civilization.Nature)
        {
            AddSpellAbilities(new EnchantedSoilEffect());
        }
    }

    class EnchantedSoilEffect : OneShotEffects.FromGraveyardIntoManaZoneEffect
    {
        public EnchantedSoilEffect() : base(new CardFilters.OwnersGraveyardCreatureFilter(), 0, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EnchantedSoilEffect();
        }

        public override string ToString()
        {
            return "Put up to 2 creatures from your graveyard into your mana zone.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Graveyard.Creatures;
        }
    }
}
