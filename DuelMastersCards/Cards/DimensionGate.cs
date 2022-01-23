using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class DimensionGate : Spell
    {
        public DimensionGate() : base("Dimension Gate", 3, Civilization.Nature)
        {
            ShieldTrigger = true;

            // Search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new SpellAbility(new SearchDeckEffect(new OwnersDeckCreatureFilter(), true)));
        }
    }
}
